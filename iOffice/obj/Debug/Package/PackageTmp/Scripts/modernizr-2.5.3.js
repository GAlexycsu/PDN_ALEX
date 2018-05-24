window.Modernizr = function(k, d, n) {
    function l(e, b) {
        return typeof e === b;
    }
    function B(e, b) {
        for (var p in e) {
            if (h[e[p]] !== n) {
                return "pfx" == b ? e[p] : !0;
            }
        }
        return !1;
    }
    function g(e, b, p) {
        var a = e.charAt(0).toUpperCase() + e.substr(1), d = (e + " " + r.join(a + " ") + a).split(" ");
        if (l(b, "string") || l(b, "undefined")) {
            return B(d, b);
        }
        d = (e + " " + C.join(a + " ") + a).split(" ");
        a: {
            e = d;
            for (var c in e) {
                if (a = b[e[c]], a !== n) {
                    b = !1 === p ? e[c] : l(a, "function") ? a.bind(p || b) : a;
                    break a;
                }
            }
            b = !1;
        }
        return b;
    }
    function G() {
        c.input = function(e) {
            for (var b = 0, a = e.length;b < a;b++) {
                t[e[b]] = !!(e[b] in f);
            }
            t.list && (t.list = !(!d.createElement("datalist") || !k.HTMLDataListElement));
            return t;
        }("autocomplete autofocus list placeholder max min multiple pattern required step".split(" "));
        c.inputtypes = function(e) {
            for (var b = 0, a, c, k = e.length;b < k;b++) {
                f.setAttribute("type", c = e[b]);
                if (a = "text" !== f.type) {
                    f.value = ":)", f.style.cssText = "position:absolute;visibility:hidden;", /^range$/.test(c) && f.style.WebkitAppearance !== n ? (m.appendChild(f), a = d.defaultView, a = a.getComputedStyle && "textfield" !== a.getComputedStyle(f, null).WebkitAppearance && 0 !== f.offsetHeight, m.removeChild(f)) : /^(search|tel)$/.test(c) || (/^(url|email)$/.test(c) ? a = f.checkValidity && !1 === f.checkValidity() : /^color$/.test(c) ? (m.appendChild(f), m.offsetWidth, a = ":)" != f.value, m.removeChild(f)) : 
                    a = ":)" != f.value);
                }
                D[e[b]] = !!a;
            }
            return D;
        }("search tel url email datetime date month week time datetime-local number range color".split(" "));
    }
    var c = {}, m = d.documentElement, a = d.createElement("modernizr"), h = a.style, f = d.createElement("input"), E = {}.toString, q = " -webkit- -moz- -o- -ms- ".split(" "), r = ["Webkit", "Moz", "O", "ms"], C = ["webkit", "moz", "o", "ms"], a = {}, D = {}, t = {}, v = [], w = v.slice, u, x = function(e, b, a, c) {
        var k, f = d.createElement("div"), g = d.body, h = g ? g : d.createElement("body");
        if (parseInt(a, 10)) {
            for (;a--;) {
                k = d.createElement("div"), k.id = c ? c[a] : "modernizr" + (a + 1), f.appendChild(k);
            }
        }
        a = ["&#173;<style>", e, "</style>"].join("");
        f.id = "modernizr";
        h.innerHTML += a;
        h.appendChild(f);
        g || (h.style.background = "", m.appendChild(h));
        e = b(f, e);
        g ? f.parentNode.removeChild(f) : h.parentNode.removeChild(h);
        return !!e;
    }, F = function() {
        var e = {select:"input", change:"input", submit:"form", reset:"form", error:"img", load:"img", abort:"img"};
        return function(b, a) {
            a = a || d.createElement(e[b] || "div");
            b = "on" + b;
            var c = b in a;
            c || (a.setAttribute || (a = d.createElement("div")), a.setAttribute && a.removeAttribute && (a.setAttribute(b, ""), c = l(a[b], "function"), l(a[b], "undefined") || (a[b] = n), a.removeAttribute(b)));
            return c;
        };
    }(), y = {}.hasOwnProperty, z;
    z = l(y, "undefined") || l(y.call, "undefined") ? function(e, a) {
        return a in e && l(e.constructor.prototype[a], "undefined");
    } : function(e, a) {
        return y.call(e, a);
    };
    Function.prototype.bind || (Function.prototype.bind = function(e) {
        var a = this;
        if ("function" != typeof a) {
            throw new TypeError;
        }
        var c = w.call(arguments, 1), d = function() {
            if (this instanceof d) {
                var f = function() {
                };
                f.prototype = a.prototype;
                var f = new f, k = a.apply(f, c.concat(w.call(arguments)));
                return Object(k) === k ? k : f;
            }
            return a.apply(e, c.concat(w.call(arguments)));
        };
        return d;
    });
    (function(a, b) {
        var f = a.join(""), h = b.length;
        x(f, function(a, e) {
            for (var b = d.styleSheets[d.styleSheets.length - 1], b = b ? b.cssRules && b.cssRules[0] ? b.cssRules[0].cssText : b.cssText || "" : "", f = a.childNodes, g = {};h--;) {
                g[f[h].id] = f[h];
            }
            c.touch = "ontouchstart" in k || k.DocumentTouch && d instanceof DocumentTouch || 9 === (g.touch && g.touch.offsetTop);
            c.csstransforms3d = 9 === (g.csstransforms3d && g.csstransforms3d.offsetLeft) && 3 === g.csstransforms3d.offsetHeight;
            c.generatedcontent = 1 <= (g.generatedcontent && g.generatedcontent.offsetHeight);
            c.fontface = /src/i.test(b) && 0 === b.indexOf(e.split(" ")[0]);
        }, h, b);
    })(['@font-face {font-family:"font";src:url("https://")}', ["@media (", q.join("touch-enabled),("), "modernizr){#touch{top:9px;position:absolute}}"].join(""), ["@media (", q.join("transform-3d),("), "modernizr){#csstransforms3d{left:9px;position:absolute;height:3px;}}"].join(""), '#generatedcontent:after{content:":)";visibility:hidden}'], ["fontface", "touch", "csstransforms3d", "generatedcontent"]);
    a.flexbox = function() {
        return g("flexOrder");
    };
    a["flexbox-legacy"] = function() {
        return g("boxDirection");
    };
    a.canvas = function() {
        var a = d.createElement("canvas");
        return !(!a.getContext || !a.getContext("2d"));
    };
    a.canvastext = function() {
        return !(!c.canvas || !l(d.createElement("canvas").getContext("2d").fillText, "function"));
    };
    a.webgl = function() {
        try {
            var a = d.createElement("canvas"), b;
            b = !(!k.WebGLRenderingContext || !a.getContext("experimental-webgl") && !a.getContext("webgl"));
        } catch (c) {
            b = !1;
        }
        return b;
    };
    a.touch = function() {
        return c.touch;
    };
    a.geolocation = function() {
        return !!navigator.geolocation;
    };
    a.postmessage = function() {
        return !!k.postMessage;
    };
    a.websqldatabase = function() {
        return !!k.openDatabase;
    };
    a.indexedDB = function() {
        return !!g("indexedDB", k);
    };
    a.hashchange = function() {
        return F("hashchange", k) && (d.documentMode === n || 7 < d.documentMode);
    };
    a.history = function() {
        return !(!k.history || !history.pushState);
    };
    a.draganddrop = function() {
        var a = d.createElement("div");
        return "draggable" in a || "ondragstart" in a && "ondrop" in a;
    };
    a.websockets = function() {
        for (var a = -1, b = r.length;++a < b;) {
            if (k[r[a] + "WebSocket"]) {
                return !0;
            }
        }
        return "WebSocket" in k;
    };
    a.rgba = function() {
        h.cssText = "background-color:rgba(150,255,150,.5)";
        return !!~("" + h.backgroundColor).indexOf("rgba");
    };
    a.hsla = function() {
        h.cssText = "background-color:hsla(120,40%,100%,.5)";
        return !!~("" + h.backgroundColor).indexOf("rgba") || !!~("" + h.backgroundColor).indexOf("hsla");
    };
    a.multiplebgs = function() {
        h.cssText = "background:url(https://),url(https://),red url(https://)";
        return /(urls*(.*?){3}/.test(h.background);
    };
    a.backgroundsize = function() {
        return g("backgroundSize");
    };
    a.borderimage = function() {
        return g("borderImage");
    };
    a.borderradius = function() {
        return g("borderRadius");
    };
    a.boxshadow = function() {
        return g("boxShadow");
    };
    a.textshadow = function() {
        return "" === d.createElement("div").style.textShadow;
    };
    a.opacity = function() {
        var a = q.join("opacity:.55;") + "";
        h.cssText = a;
        return /^0.55$/.test(h.opacity);
    };
    a.cssanimations = function() {
        return g("animationName");
    };
    a.csscolumns = function() {
        return g("columnCount");
    };
    a.cssgradients = function() {
        var a = ("background-image:-webkit-gradient(linear,left top,right bottom,from(#9f9),to(white));background-image:" + q.join("linear-gradient(left top,#9f9, white);background-image:")).slice(0, -17);
        h.cssText = a;
        return !!~("" + h.backgroundImage).indexOf("gradient");
    };
    a.cssreflections = function() {
        return g("boxReflect");
    };
    a.csstransforms = function() {
        return !!g("transform");
    };
    a.csstransforms3d = function() {
        var a = !!g("perspective");
        a && "webkitPerspective" in m.style && (a = c.csstransforms3d);
        return a;
    };
    a.csstransitions = function() {
        return g("transition");
    };
    a.fontface = function() {
        return c.fontface;
    };
    a.generatedcontent = function() {
        return c.generatedcontent;
    };
    a.video = function() {
        var a = d.createElement("video"), b = !1;
        try {
            if (b = !!a.canPlayType) {
                b = new Boolean(b), b.ogg = a.canPlayType('video/ogg; codecs="theora"').replace(/^no$/, ""), b.h264 = a.canPlayType('video/mp4; codecs="avc1.42E01E"').replace(/^no$/, ""), b.webm = a.canPlayType('video/webm; codecs="vp8, vorbis"').replace(/^no$/, "");
            }
        } catch (c) {
        }
        return b;
    };
    a.audio = function() {
        var a = d.createElement("audio"), b = !1;
        try {
            if (b = !!a.canPlayType) {
                b = new Boolean(b), b.ogg = a.canPlayType('audio/ogg; codecs="vorbis"').replace(/^no$/, ""), b.mp3 = a.canPlayType("audio/mpeg;").replace(/^no$/, ""), b.wav = a.canPlayType('audio/wav; codecs="1"').replace(/^no$/, ""), b.m4a = (a.canPlayType("audio/x-m4a;") || a.canPlayType("audio/aac;")).replace(/^no$/, "");
            }
        } catch (c) {
        }
        return b;
    };
    a.localstorage = function() {
        try {
            return localStorage.setItem("modernizr", "modernizr"), localStorage.removeItem("modernizr"), !0;
        } catch (a) {
            return !1;
        }
    };
    a.sessionstorage = function() {
        try {
            return sessionStorage.setItem("modernizr", "modernizr"), sessionStorage.removeItem("modernizr"), !0;
        } catch (a) {
            return !1;
        }
    };
    a.webworkers = function() {
        return !!k.Worker;
    };
    a.applicationcache = function() {
        return !!k.applicationCache;
    };
    a.svg = function() {
        return !!d.createElementNS && !!d.createElementNS("http://www.w3.org/2000/svg", "svg").createSVGRect;
    };
    a.inlinesvg = function() {
        var a = d.createElement("div");
        a.innerHTML = "<svg/>";
        return "http://www.w3.org/2000/svg" == (a.firstChild && a.firstChild.namespaceURI);
    };
    a.smil = function() {
        return !!d.createElementNS && /SVGAnimate/.test(E.call(d.createElementNS("http://www.w3.org/2000/svg", "animate")));
    };
    a.svgclippaths = function() {
        return !!d.createElementNS && /SVGClipPath/.test(E.call(d.createElementNS("http://www.w3.org/2000/svg", "clipPath")));
    };
    for (var A in a) {
        z(a, A) && (u = A.toLowerCase(), c[u] = a[A](), v.push((c[u] ? "" : "no-") + u));
    }
    c.input || G();
    c.addTest = function(a, b) {
        if ("object" == typeof a) {
            for (var d in a) {
                z(a, d) && c.addTest(d, a[d]);
            }
        } else {
            a = a.toLowerCase();
            if (c[a] !== n) {
                return c;
            }
            b = "function" == typeof b ? b() : b;
            m.className += " " + (b ? "" : "no-") + a;
            c[a] = b;
        }
        return c;
    };
    h.cssText = "";
    a = f = null;
    (function(a, b) {
        function c() {
            var a = l.elements;
            return "string" == typeof a ? a.split(" ") : a;
        }
        function d(a) {
            var b = {}, e = a.createElement, f = a.createDocumentFragment, g = f();
            a.createElement = function(a) {
                var c = (b[a] || (b[a] = e(a))).cloneNode();
                return l.shivMethods && c.canHaveChildren && !k.test(a) ? g.appendChild(c) : c;
            };
            a.createDocumentFragment = Function("h,f", "return function(){var n=f.cloneNode(),c=n.createElement;h.shivMethods&&(" + c().join().replace(/w+/g, function(a) {
                b[a] = e(a);
                g.createElement(a);
                return 'c("' + a + '")';
            }) + ");return n}")(l, g);
        }
        function f(a) {
            var b;
            if (a.documentShived) {
                return a;
            }
            if (l.shivCSS && !h) {
                b = a.createElement("p");
                var c = a.getElementsByTagName("head")[0] || a.documentElement;
                b.innerHTML = "x<style>article,aside,details,figcaption,figure,footer,header,hgroup,nav,section{display:block}audio{display:none}canvas,video{display:inline-block;*display:inline;*zoom:1}[hidden]{display:none}audio[controls]{display:inline-block;*display:inline;*zoom:1}mark{background:#FF0;color:#000}</style>";
                b = !!c.insertBefore(b.lastChild, c.firstChild);
            }
            m || (b = !d(a));
            b && (a.documentShived = b);
            return a;
        }
        var g = a.html5 || {}, k = /^<|^(?:button|form|map|select|textarea)$/i, h, m;
        (function() {
            var a = b.createElement("a");
            a.innerHTML = "<xyz></xyz>";
            h = "hidden" in a;
            if (!(a = 1 == a.childNodes.length)) {
                a: {
                    try {
                        b.createElement("a");
                    } catch (c) {
                        a = !0;
                        break a;
                    }
                    a = b.createDocumentFragment();
                    a = "undefined" == typeof a.cloneNode || "undefined" == typeof a.createDocumentFragment || "undefined" == typeof a.createElement;
                }
            }
            m = a;
        })();
        var l = {elements:g.elements || "abbr article aside audio bdi canvas data datalist details figcaption figure footer header hgroup mark meter nav output progress section summary time video", shivCSS:!1 !== g.shivCSS, shivMethods:!1 !== g.shivMethods, type:"default", shivDocument:f};
        a.html5 = l;
        f(b);
    })(this, d);
    c._version = "2.5.3";
    c._prefixes = q;
    c._domPrefixes = C;
    c._cssomPrefixes = r;
    c.mq = function(a) {
        var b = k.matchMedia || k.msMatchMedia;
        if (b) {
            return b(a).matches;
        }
        var c;
        x("@media " + a + " { #modernizr { position: absolute; } }", function(a) {
            c = "absolute" == (k.getComputedStyle ? getComputedStyle(a, null) : a.currentStyle).position;
        });
        return c;
    };
    c.hasEvent = F;
    c.testProp = function(a) {
        return B([a]);
    };
    c.testAllProps = g;
    c.testStyles = x;
    c.prefixed = function(a, b, c) {
        return b ? g(a, b, c) : g(a, "pfx");
    };
    m.className = m.className.replace(/(^|s)no-js(s|$)/, "$1$2") + (" js " + v.join(" "));
    return c;
}(this, this.document);

