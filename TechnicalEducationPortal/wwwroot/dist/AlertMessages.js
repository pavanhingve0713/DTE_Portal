$('#submit-btn').on('click', function (e) {
    e.preventDefault();
    var form = $('.pt_upld_page_frm');
    SweetAlertfun("Do you want to save this record?", form)
});


$('#submit-update-btn').on('click', function (e) {
    e.preventDefault();
    var form = $('.pt_upld_page_frm');
    SweetAlertfun("Do you want to edit details?", form)
});

function SweetAlertfun(text, form) {
    swal.fire({
        text: text,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        closeOnConfirm: false
    }).then(function (isConfirm) {
        if (isConfirm.dismiss !== "cancel" && isConfirm.dismiss !== "esc") {
            debugger;
            form.submit();
        }
        else {
            return false;
        }
    });
    return false;
}