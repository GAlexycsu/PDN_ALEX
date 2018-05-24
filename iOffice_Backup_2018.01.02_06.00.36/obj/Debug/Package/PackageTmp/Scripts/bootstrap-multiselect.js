!function (b) {
    function m(a) { return ko.isObservable(a) && void 0 !== a.destroyAll } function n(a, b) { for (var d = 0; d < a.length; ++d) b(a[d]) } function k(a, c) {
        this.$select = b(a); this.options = this.mergeOptions(b.extend({}, c, this.$select.data())); this.originalOptions = this.$select.clone()[0].options; this.query = ""; this.searchTimeout = null; this.options.multiple = "multiple" === this.$select.attr("multiple"); this.options.onChange = b.proxy(this.options.onChange, this); this.options.onDropdownShow = b.proxy(this.options.onDropdownShow,
        this); this.options.onDropdownHide = b.proxy(this.options.onDropdownHide, this); this.options.onDropdownShown = b.proxy(this.options.onDropdownShown, this); this.options.onDropdownHidden = b.proxy(this.options.onDropdownHidden, this); this.buildContainer(); this.buildButton(); this.buildDropdown(); this.buildSelectAll(); this.buildDropdownOptions(); this.buildFilter(); this.updateButtonText(); this.updateSelectAll(); this.options.disableIfEmpty && 0 >= b("option", this.$select).length && this.disable(); this.$select.hide().after(this.$container)
    }
    "undefined" !== typeof ko && ko.bindingHandlers && !ko.bindingHandlers.multiselect && (ko.bindingHandlers.multiselect = {
        init: function (a, c, d, e, f) {
            d = d().selectedOptions; c = ko.utils.unwrapObservable(c()); b(a).multiselect(c); m(d) && (b(a).multiselect("select", ko.utils.unwrapObservable(d)), d.subscribe(function (c) { var d = [], e = []; n(c, function (a) { switch (a.status) { case "added": d.push(a.value); break; case "deleted": e.push(a.value) } }); 0 < d.length && b(a).multiselect("select", d); 0 < e.length && b(a).multiselect("deselect", e) }, null,
            "arrayChange"))
        }, update: function (a, c, d, e, f) { d = d().options; e = b(a).data("multiselect"); c = ko.utils.unwrapObservable(c()); m(d) && d.subscribe(function (c) { b(a).multiselect("rebuild") }); e ? e.updateOriginalOptions() : b(a).multiselect(c) }
    }); k.prototype = {
        defaults: {
            buttonText: function (a, c) {
                if (0 === a.length) return this.nonSelectedText + ' <b class="caret"></b>'; if (a.length == b("option", b(c)).length) return this.allSelectedText + ' <b class="caret"></b>'; if (a.length > this.numberDisplayed) return a.length + " " + this.nSelectedText +
                ' <b class="caret"></b>'; var d = ""; a.each(function () { var a = void 0 !== b(this).attr("label") ? b(this).attr("label") : b(this).html(); d += a + ", " }); return d.substr(0, d.length - 2) + ' <b class="caret"></b>'
            }, buttonTitle: function (a, c) { if (0 === a.length) return this.nonSelectedText; var d = ""; a.each(function () { d += b(this).text() + ", " }); return d.substr(0, d.length - 2) }, label: function (a) { return b(a).attr("label") || b(a).html() }, onChange: function (a, b) { }, onDropdownShow: function (a) { }, onDropdownHide: function (a) { }, onDropdownShown: function (a) { },
            onDropdownHidden: function (a) { }, buttonClass: "btn btn-default", buttonWidth: "auto", buttonContainer: '<div class="btn-group" />', dropRight: !1, selectedClass: "active", maxHeight: !1, checkboxName: !1, includeSelectAllOption: !1, includeSelectAllIfMoreThan: 0, selectAllText: " Select all", selectAllValue: "multiselect-all", selectAllName: !1, enableFiltering: !1, enableCaseInsensitiveFiltering: !1, enableClickableOptGroups: !1, filterPlaceholder: "Search", filterBehavior: "text", includeFilterClearBtn: !0, preventInputChangeEvent: !1,
            nonSelectedText: "None selected", nSelectedText: "selected", allSelectedText: "All selected", numberDisplayed: 3, disableIfEmpty: !1, templates: {
                button: '<button type="button" class="multiselect dropdown-toggle" data-toggle="dropdown"></button>', ul: '<ul class="multiselect-container dropdown-menu"></ul>', filter: '<li class="multiselect-item filter"><div class="input-group"><span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span><input class="form-control multiselect-search" type="text"></div></li>',
                filterClearBtn: '<span class="input-group-btn"><button class="btn btn-default multiselect-clear-filter" type="button"><i class="glyphicon glyphicon-remove-circle"></i></button></span>', li: '<li><a href="javascript:void(0);"><label></label></a></li>', divider: '<li class="multiselect-item divider"></li>', liGroup: '<li class="multiselect-item multiselect-group"><label></label></li>'
            }
        }, constructor: k, buildContainer: function () {
            this.$container = b(this.options.buttonContainer); this.$container.on("show.bs.dropdown",
            this.options.onDropdownShow); this.$container.on("hide.bs.dropdown", this.options.onDropdownHide); this.$container.on("shown.bs.dropdown", this.options.onDropdownShown); this.$container.on("hidden.bs.dropdown", this.options.onDropdownHidden)
        }, buildButton: function () {
            this.$button = b(this.options.templates.button).addClass(this.options.buttonClass); this.$select.prop("disabled") ? this.disable() : this.enable(); this.options.buttonWidth && "auto" !== this.options.buttonWidth && (this.$button.css({ width: this.options.buttonWidth }),
            this.$container.css({ width: this.options.buttonWidth })); var a = this.$select.attr("tabindex"); a && this.$button.attr("tabindex", a); this.$container.prepend(this.$button)
        }, buildDropdown: function () { this.$ul = b(this.options.templates.ul); this.options.dropRight && this.$ul.addClass("pull-right"); this.options.maxHeight && this.$ul.css({ "max-height": this.options.maxHeight + "px", "overflow-y": "auto", "overflow-x": "hidden" }); this.$container.append(this.$ul) }, buildDropdownOptions: function () {
            this.$select.children().each(b.proxy(function (a,
            c) { var d = b(c), e = d.prop("tagName").toLowerCase(); d.prop("value") !== this.options.selectAllValue && ("optgroup" === e ? this.createOptgroup(c) : "option" === e && ("divider" === d.data("role") ? this.createDivider() : this.createOptionValue(c))) }, this)); b("li input", this.$ul).on("change", b.proxy(function (a) {
                var c = b(a.target); a = c.prop("checked") || !1; var d = c.val() === this.options.selectAllValue; this.options.selectedClass && (a ? c.closest("li").addClass(this.options.selectedClass) : c.closest("li").removeClass(this.options.selectedClass));
                var e = c.val(), e = this.getOptionByValue(e), f = b("option", this.$select).not(e), c = b("input", this.$container).not(c); d && (a ? this.selectAll() : this.deselectAll()); d || (a ? (e.prop("selected", !0), this.options.multiple ? e.prop("selected", !0) : (this.options.selectedClass && b(c).closest("li").removeClass(this.options.selectedClass), b(c).prop("checked", !1), f.prop("selected", !1), this.$button.click()), "active" === this.options.selectedClass && f.closest("a").css("outline", "")) : e.prop("selected", !1)); this.$select.change();
                this.updateButtonText(); this.updateSelectAll(); this.options.onChange(e, a); if (this.options.preventInputChangeEvent) return !1
            }, this)); b("li a", this.$ul).on("touchstart click", function (a) {
                a.stopPropagation(); var c = b(a.target); if ("Range" === document.getSelection().type) { var d = b(this).find("input:first"); d.prop("checked", !d.prop("checked")).trigger("change") } if (a.shiftKey && c.prop("checked")) {
                    a = c.closest("li").siblings('li[class="active"]:first'); var d = c.closest("li").index(), e = a.index(); d > e ? c.closest("li").prevUntil(a).each(function () {
                        b(this).find("input:first").prop("checked",
                        !0).trigger("change")
                    }) : c.closest("li").nextUntil(a).each(function () { b(this).find("input:first").prop("checked", !0).trigger("change") })
                } c.blur()
            }); this.$container.off("keydown.multiselect").on("keydown.multiselect", b.proxy(function (a) {
                if (!b('input[type="text"]', this.$container).is(":focus")) if (9 === a.keyCode && this.$container.hasClass("open")) this.$button.click(); else {
                    var c = b(this.$container).find("li:not(.divider):not(.disabled) a").filter(":visible"); if (c.length) {
                        var d = c.index(c.filter(":focus"));
                        38 === a.keyCode && 0 < d ? d-- : 40 === a.keyCode && d < c.length - 1 ? d++ : ~d || (d = 0); c = c.eq(d); c.focus(); if (32 === a.keyCode || 13 === a.keyCode) c = c.find("input"), c.prop("checked", !c.prop("checked")), c.change(); a.stopPropagation(); a.preventDefault()
                    }
                }
            }, this)); if (this.options.enableClickableOptGroups && this.options.multiple) b("li.multiselect-group", this.$ul).on("click", b.proxy(function (a) {
                a.stopPropagation(); var c = !0; a = b(a.target).parent().nextUntil("li.multiselect-group").find("input"); a.each(function () { c = c && b(this).prop("checked") });
                a.prop("checked", !c).trigger("change")
            }, this))
        }, createOptionValue: function (a) {
            var c = b(a); c.is(":selected") && c.prop("selected", !0); a = this.options.label(a); var d = c.val(), e = this.options.multiple ? "checkbox" : "radio", f = b(this.options.templates.li), h = b("label", f); h.addClass(e); e = b("<input/>").attr("type", e); this.options.checkboxName && e.attr("name", this.options.checkboxName); h.append(e); var g = c.prop("selected") || !1; e.val(d); d === this.options.selectAllValue && (f.addClass("multiselect-item multiselect-all"),
            e.parent().parent().addClass("multiselect-all")); h.append(" " + a); h.attr("title", c.attr("title")); this.$ul.append(f); c.is(":disabled") && e.attr("disabled", "disabled").prop("disabled", !0).closest("a").attr("tabindex", "-1").closest("li").addClass("disabled"); e.prop("checked", g); g && this.options.selectedClass && e.closest("li").addClass(this.options.selectedClass)
        }, createDivider: function (a) { a = b(this.options.templates.divider); this.$ul.append(a) }, createOptgroup: function (a) {
            var c = b(a).prop("label"), d = b(this.options.templates.liGroup);
            b("label", d).text(c); this.options.enableClickableOptGroups && d.addClass("multiselect-group-clickable"); this.$ul.append(d); b(a).is(":disabled") && d.addClass("disabled"); b("option", a).each(b.proxy(function (a, b) { this.createOptionValue(b) }, this))
        }, buildSelectAll: function () {
            "number" === typeof this.options.selectAllValue && (this.options.selectAllValue = this.options.selectAllValue.toString()); if (!this.hasSelectAll() && this.options.includeSelectAllOption && this.options.multiple && b("option", this.$select).length >
            this.options.includeSelectAllIfMoreThan) {
                this.options.includeSelectAllDivider && this.$ul.prepend(b(this.options.templates.divider)); var a = b(this.options.templates.li); b("label", a).addClass("checkbox"); this.options.selectAllName ? b("label", a).append('<input type="checkbox" name="' + this.options.selectAllName + '" />') : b("label", a).append('<input type="checkbox" />'); var c = b("input", a); c.val(this.options.selectAllValue); a.addClass("multiselect-item multiselect-all"); c.parent().parent().addClass("multiselect-all");
                b("label", a).append(" " + this.options.selectAllText); this.$ul.prepend(a); c.prop("checked", !1)
            }
        }, buildFilter: function () {
            if (this.options.enableFiltering || this.options.enableCaseInsensitiveFiltering) {
                var a = Math.max(this.options.enableFiltering, this.options.enableCaseInsensitiveFiltering); this.$select.find("option").length >= a && (this.$filter = b(this.options.templates.filter), b("input", this.$filter).attr("placeholder", this.options.filterPlaceholder), this.options.includeFilterClearBtn && (a = b(this.options.templates.filterClearBtn),
                a.on("click", b.proxy(function (a) { clearTimeout(this.searchTimeout); this.$filter.find(".multiselect-search").val(""); b("li", this.$ul).show().removeClass("filter-hidden"); this.updateSelectAll() }, this)), this.$filter.find(".input-group").append(a)), this.$ul.prepend(this.$filter), this.$filter.val(this.query).on("click", function (a) { a.stopPropagation() }).on("input keydown", b.proxy(function (a) {
                    13 === a.which && a.preventDefault(); clearTimeout(this.searchTimeout); this.searchTimeout = this.asyncFunction(b.proxy(function () {
                        if (this.query !==
                        a.target.value) {
                            this.query = a.target.value; var d, e; b.each(b("li", this.$ul), b.proxy(function (a, c) {
                                var g = b("input", c).val(), k = b("label", c).text(), l = ""; "text" === this.options.filterBehavior ? l = k : "value" === this.options.filterBehavior ? l = g : "both" === this.options.filterBehavior && (l = k + "n" + g); g !== this.options.selectAllValue && k && (g = !1, this.options.enableCaseInsensitiveFiltering && -1 < l.toLowerCase().indexOf(this.query.toLowerCase()) ? g = !0 : -1 < l.indexOf(this.query) && (g = !0), b(c).toggle(g).toggleClass("filter-hidden",
                                !g), b(c).hasClass("multiselect-group") ? (d = c, e = g) : (g && b(d).show().removeClass("filter-hidden"), !g && e && b(c).show().removeClass("filter-hidden")))
                            }, this))
                        } this.updateSelectAll()
                    }, this), 300, this)
                }, this)))
            }
        }, destroy: function () { this.$container.remove(); this.$select.show(); this.$select.data("multiselect", null) }, refresh: function () {
            b("option", this.$select).each(b.proxy(function (a, c) {
                var d = b("li input", this.$ul).filter(function () { return b(this).val() === b(c).val() }); b(c).is(":selected") ? (d.prop("checked", !0),
                this.options.selectedClass && d.closest("li").addClass(this.options.selectedClass)) : (d.prop("checked", !1), this.options.selectedClass && d.closest("li").removeClass(this.options.selectedClass)); b(c).is(":disabled") ? d.attr("disabled", "disabled").prop("disabled", !0).closest("li").addClass("disabled") : d.prop("disabled", !1).closest("li").removeClass("disabled")
            }, this)); this.updateButtonText(); this.updateSelectAll()
        }, select: function (a, c) {
            b.isArray(a) || (a = [a]); for (var d = 0; d < a.length; d++) {
                var e = a[d]; if (null !==
                e && void 0 !== e) { var f = this.getOptionByValue(e), e = this.getInputByValue(e); void 0 !== f && void 0 !== e && (this.options.multiple || this.deselectAll(!1), this.options.selectedClass && e.closest("li").addClass(this.options.selectedClass), e.prop("checked", !0), f.prop("selected", !0)) }
            } this.updateButtonText(); this.updateSelectAll(); if (c && 1 === a.length) this.options.onChange(f, !0)
        }, clearSelection: function () { this.deselectAll(!1); this.updateButtonText(); this.updateSelectAll() }, deselect: function (a, c) {
            b.isArray(a) || (a = [a]);
            for (var d = 0; d < a.length; d++) { var e = a[d]; if (null !== e && void 0 !== e) { var f = this.getOptionByValue(e), e = this.getInputByValue(e); void 0 !== f && void 0 !== e && (this.options.selectedClass && e.closest("li").removeClass(this.options.selectedClass), e.prop("checked", !1), f.prop("selected", !1)) } } this.updateButtonText(); this.updateSelectAll(); if (c && 1 === a.length) this.options.onChange(f, !1)
        }, selectAll: function (a) {
            a = "undefined" === typeof a ? !0 : a; var c = b("li input[type='checkbox']:enabled", this.$ul), d = c.filter(":visible"), e =
            c.length, f = d.length; a ? (d.prop("checked", !0), b("li:not(.divider):not(.disabled)", this.$ul).filter(":visible").addClass(this.options.selectedClass)) : (c.prop("checked", !0), b("li:not(.divider):not(.disabled)", this.$ul).addClass(this.options.selectedClass)); if (e === f || !1 === a) b("option:enabled", this.$select).prop("selected", !0); else { var h = d.map(function () { return b(this).val() }).get(); b("option:enabled", this.$select).filter(function (a) { return -1 !== b.inArray(b(this).val(), h) }).prop("selected", !0) }
        }, deselectAll: function (a) {
            if ("undefined" ===
            typeof a || a) { a = b("li input[type='checkbox']:enabled", this.$ul).filter(":visible"); a.prop("checked", !1); var c = a.map(function () { return b(this).val() }).get(); b("option:enabled", this.$select).filter(function (a) { return -1 !== b.inArray(b(this).val(), c) }).prop("selected", !1); this.options.selectedClass && b("li:not(.divider):not(.disabled)", this.$ul).filter(":visible").removeClass(this.options.selectedClass) } else b("li input[type='checkbox']:enabled", this.$ul).prop("checked", !1), b("option:enabled", this.$select).prop("selected",
            !1), this.options.selectedClass && b("li:not(.divider):not(.disabled)", this.$ul).removeClass(this.options.selectedClass)
        }, rebuild: function () { this.$ul.html(""); this.options.multiple = "multiple" === this.$select.attr("multiple"); this.buildSelectAll(); this.buildDropdownOptions(); this.buildFilter(); this.updateButtonText(); this.updateSelectAll(); this.options.disableIfEmpty && 0 >= b("option", this.$select).length && this.disable(); this.options.dropRight && this.$ul.addClass("pull-right") }, dataprovider: function (a) {
            var c =
            0, d = b(""); b.each(a, function (a, f) { var h; b.isArray(f.children) ? (c++, h = b("<optgroup/>").attr({ label: f.label || "Group " + c }), n(f.children, function (a) { h.append(b("<option/>").attr({ value: a.value, label: a.label || a.value, title: a.title, selected: !!a.selected })) })) : h = b("<option/>").attr({ value: f.value, label: f.label || f.value, title: f.title, selected: !!f.selected }); d = d.add(h) }); this.$select.empty().append(d); this.rebuild()
        }, enable: function () { this.$select.prop("disabled", !1); this.$button.prop("disabled", !1).removeClass("disabled") },
        disable: function () { this.$select.prop("disabled", !0); this.$button.prop("disabled", !0).addClass("disabled") }, setOptions: function (a) { this.options = this.mergeOptions(a) }, mergeOptions: function (a) { return b.extend(!0, {}, this.defaults, a) }, hasSelectAll: function () { return 0 < b("li." + this.options.selectAllValue, this.$ul).length }, updateSelectAll: function () {
            if (this.hasSelectAll()) {
                var a = b("li:not(.multiselect-item):not(.filter-hidden) input:enabled", this.$ul), c = a.length, a = a.filter(":checked").length, d = b("li." + this.options.selectAllValue,
                this.$ul), e = d.find("input"); 0 < a && a === c ? (e.prop("checked", !0), d.addClass(this.options.selectedClass)) : (e.prop("checked", !1), d.removeClass(this.options.selectedClass))
            }
        }, updateButtonText: function () { var a = this.getSelected(); b(".multiselect", this.$container).html(this.options.buttonText(a, this.$select)); b(".multiselect", this.$container).attr("title", this.options.buttonTitle(a, this.$select)) }, getSelected: function () { return b("option", this.$select).filter(":selected") }, getOptionByValue: function (a) {
            var c =
            b("option", this.$select); a = a.toString(); for (var d = 0; d < c.length; d += 1) { var e = c[d]; if (e.value === a) return b(e) }
        }, getInputByValue: function (a) { var c = b("li input", this.$ul); a = a.toString(); for (var d = 0; d < c.length; d += 1) { var e = c[d]; if (e.value === a) return b(e) } }, updateOriginalOptions: function () { this.originalOptions = this.$select.clone()[0].options }, asyncFunction: function (a, b, d) { var e = Array.prototype.slice.call(arguments, 3); return setTimeout(function () { a.apply(d || window, e) }, b) }
    }; b.fn.multiselect = function (a, c, d) {
        return this.each(function () {
            var e =
            b(this).data("multiselect"), f = "object" === typeof a && a; e || (e = new k(this, f), b(this).data("multiselect", e)); "string" === typeof a && (e[a](c, d), "destroy" === a && b(this).data("multiselect", !1))
        })
    }; b.fn.multiselect.Constructor = k; b(function () { b("select[data-role=multiselect]").multiselect() })
}(window.jQuery);
