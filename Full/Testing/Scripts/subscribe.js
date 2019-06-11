(function (filename, callbackStorage, context) {
    window[callbackStorage] = window[callbackStorage] || [];

    context.init = function (sw) {
        Notification.requestPermission().then(function (permission) {
            for (var i in window[callbackStorage]) {
                window[callbackStorage][i](permission);
            }

            if ('granted' !== permission) {
                return;
            }

            sw.getRegistrations().then(function (registrations) {
                for (var i in registrations) {
                    if (registrations[i].active && registrations[i].active.scriptURL.indexOf(filename) !== -1) {
                        registrations[i].active.postMessage(JSON.stringify(context.getParameters()));
                        return;
                    }
                }

                sw.register(filename);

                sw.ready.then(function (registration) {
                    registration.active.postMessage(JSON.stringify(context.getParameters()));
                });
            });
        });
    };

    context.getQueryParameter = function (name) {
        var params = window.location.search.substring(1).split('&');

        for (var i = 0; i < params.length; i++) {
            var part = params[i].split('=');

            if (part[0] === name) {
                return part[1];
            }
        }
    };

    context.getParameters = function () {
        var params = {
            url: location.href,
            event: 'activate',
            utm_medium: localStorage.getItem('mg_utm_medium'),
            utm_campaign: localStorage.getItem('mg_utm_campaign'),
            cookie: document.cookie
        };

        if (document.referrer) {
            params.referrer = document.referrer;
        }

        if (typeof helper === 'object') {
            if (helper.userCountry) {
                params.country = helper.userCountry;
            }

            if (helper.userSources) {
                params.sources = helper.userSources;
            }

            if (helper.userCategories) {
                params.categories = helper.userCategories;
            }
        }

        return params;
    };

    context.getCappingOrigin = function (url) {
        url = url.match(/^https?\:\/\/([^\/?#]+)(?:[\/?#]|$)/i);
        return url[0].replace('cdn', 'c');
    };

    context.capping = function (permission, domain, img) {
        if (localStorage.getItem('mg-old-permission') !== permission) {
            domain = location.host.replace('www.', '');

            img = document.createElement('img');
            img.src = context.cappingOrigin + 'push-event-counter?permission=' + permission + '&domain=' + domain;

            localStorage.setItem('mg-old-permission', permission);
        }
    };

    var scripts = document.getElementsByTagName('script');
    context.cappingOrigin = context.getCappingOrigin((document.currentScript || scripts[scripts.length - 1]).src);

    window[callbackStorage].push(context.capping.bind(this));

    var utmMedium = context.getQueryParameter('utm_medium');
    var utmCampaign = context.getQueryParameter('utm_campaign');

    if (utmMedium) {
        localStorage.setItem('mg_utm_medium', utmMedium);
    }

    if (utmCampaign) {
        localStorage.setItem('mg_utm_campaign', utmCampaign);
    }

    if ('serviceWorker' in navigator) {
        window.addEventListener('load', function () {
            context.init(navigator.serviceWorker);
        });
    }

    var script = document.createElement('script');
    var cmhost = context.cappingOrigin.replace('siteswithcontent', 'mgid').replace('contentsitesrv', 'marketgid');

    script.src = cmhost + 'js-cookie-muidn';
    script.async = true;
    document.head.appendChild(script);
})('/firebase-messaging-sw.js?t=7', '_NotificationPermissionCallbacks', {});