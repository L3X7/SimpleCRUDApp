function CreateNew() {
    $('#formNew').html('');
    var uri = "/Home/Form";
    var postFrm = $.post(uri);
    postFrm.done(function (data) {
        $('#hdn-create').addClass('hidden');
        $('#formNew').html(data);
        $('#Name').focus();
    })

    postFrm.fail(function () {
        bootbox.alert("Connection not available!");
    })
}
function CancelNew() {
    $('#formNew').html('');
    $('#hdn-create').removeClass('hidden');
}
function AjaxSuccess() {
    if ($('#formNew .alert-success').length > 0 || $('#formNew .alert-danger').length > 0) {
        $('#hdn-create').removeClass('hidden');
        LoadList();
        setTimeout(function () { $('#formNew').html(''); }, 4000);
    }
}
function LoadList() {
    var uri = "/Home/ListUsers";
    var postFrm = $.post(uri);
    postFrm.done(function (data) {
        $('#lst-users').html(data);
        $('#datatable-user').DataTable({
            responsive: true
        });
    })

    postFrm.fail(function () {
        bootbox.alert("Connection not available!");
    })
}
function DeleteU(i) {
    bootbox.confirm({
        message: "Delete element?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            setTimeout(function () {
                if (result) {
                    var uri = "/Home/Delete";
                    var postFrm = $.post(uri, { id: i });
                    postFrm.done(function (data) {
                        if (data == 1) {
                            bootbox.alert({
                                message: "Element not exist",
                                callback: function () {

                                }
                            });
                        }
                        else {
                            LoadList();
                            bootbox.alert({
                                message: "Element delete",
                                callback: function () {

                                }
                            });
                        }
                    })
                    postFrm.fail(function () {
                        bootbox.alert("Connection not available!");

                    })
                }
                else {

                }
            }, 1000);
        }
    });
}
function DetailU(i) {
    var uri = "/Home/Detail";
    var postForm = $.post(uri, { id: i });
    postForm.done(function (data) {
        $('#hdn-create').addClass('hidden');
        $('#formNew').html(data);
    })
    postForm.fail(function () {
        bootbox.alert("Connection not available!");
    })
}
function CancelDetail() {
    $('#formNew').html('');
    $('#hdn-create').removeClass('hidden');
}
function UpdateU(i) {
    var uri = "/Home/GetUser";
    var postForm = $.post(uri, { id: i });
    postForm.done(function (data) {
        $('#hdn-create').addClass('hidden');
        $('#formNew').html(data);
        $('#Name').focus();
    })
    postForm.fail(function () {
        bootbox.alert("Connection not available!");
    })
}