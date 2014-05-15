(function () {
    "use strict";

    var browserClient = navigator.appName,
        addScroll = false,
        positionX = 0,
        positionY = 0;

    if ((navigator.userAgent.indexOf("MSIE 5") > 0) || (navigator.userAgent.indexOf("MSIE 6")) > 0) {
        addScroll = true;
    }

    document.onMouseMove = mouseMove;

    if (browserClient === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (browserClient === "Netscape") {
            positionX = evn.pageX - 5;
            positionY = evn.pageY;
        } else {
            positionX = event.x - 5;
            positionY = event.y;
        }

        if (browserClient === "Netscape") {
            if (document.layers["ToolTip"].visibility === "show") {
                popTip();
            }
        } else {
            if (document.all["ToolTip"].style.visibility === "visible") {
                popTip();
            }
        }
    }

    function popTip() {
        if (browserClient === "Netscape") {
            var theLayer = eval("document.layers[\'ToolTip\']");

            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visibility = "show";
        } else {
            theLayer = eval("document.all[\'ToolTip\']");

            if (theLayer) {
                positionX = event.x - 5;
                positionY = event.y;

                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }

                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }

                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visibility = "visible";
            }
        }
    }

    function hideTip() {
        var args = hideTip.arguments;

        if (browserClient === "Netscape") {
            document.layers['ToolTip'].visibility = "hide";
        } else {
            document.all["ToolTip"].style.visibility = "hidden";
        }
    }

    function hideMenu1() {
        if (browserClient === "Netscape") {
            document.layers["menu1"].visibility = "hide";
        } else {
            document.all["menu1"].style.visibility = "hidden";
        }
    }

    function hideMenu2() {
        if (browserClient === "Netscape") {
            document.layers["menu2"].visibility = "hide";
        } else {
            document.all["menu2"].style.visibility = "hidden";
        }
    }

    function showMenu1() {
        if (browserClient === "Netscape") {
            theLayer = eval("document.layers[\'menu1\']");
            theLayer.visibility = "show";
        } else {
            theLayer = eval("document.all[\'menu1\']");
            theLayer.style.visibility = "visible";
        }
    }

    function showMenu2() {
        if (browserClient === "Netscape") {
            theLayer = eval("document.layers[\'menu2\']");
            theLayer.visibility = 'show';
        } else {
            theLayer = eval("document.all[\'menu2\']");
            theLayer.style.visibility = "visible";
        }
    }
})();