(function () {
    function f() {
        setTimeout(function () {
            var b = Telerik.Web.UI.RadToolTip.getCurrent();
            b && b.hide();
        }, 50);
    }
    var b = window.demo = window.demo || {};
    window.nodeDropping = function (h, c) {
        var a = c.get_htmlElement(), d = $find(b.schedulerId);
        if ($telerik.$(a).parents().is("div.rsAllDay") || $telerik.$(a).parents().is("div.rsContent")) {
            var a = d.get_activeModel().getTimeSlotFromDomElement(a).get_startTime(), f = new Date(a), e = c.get_sourceNode();
            e.get_text();
            e.get_parent().get_value();
            var e = e.get_value(), g = new Telerik.Web.UI.SchedulerAppointment;
            g.set_start(a);
            g.set_end(f);
            g.set_subject(e);
            d.insertAppointment(g);
        } else {
            c.set_cancel(!0);
        }
    };
    window.formCreated = function (f, c) {
        var a = c.get_mode();
        if ((a == Telerik.Web.UI.SchedulerFormMode.AdvancedInsert || a == Telerik.Web.UI.SchedulerFormMode.AdvancedEdit) && "" != $get(b.hiddenInputAppointmentInfo).value && (a = Sys.Serialization.JavaScriptSerializer.deserialize($get(b.hiddenInputAppointmentInfo).value))) {
            $find(b.schedulerId + "_Form_Subject").set_value(a.subject + " (by " + a.speaker + ")");
            var d = $find(b.schedulerId + "_Form_StartTime").get_selectedDate(), a = new Date(d.setMinutes(d.getMinutes() + parseInt(a.duration)));
            $find(b.schedulerId + "_Form_EndTime").set_selectedDate(a);
        }
    };
    window.appointmentMoving = function (b, c) {
        f();
    };
})();

