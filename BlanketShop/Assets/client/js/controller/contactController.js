var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();

            name = $.trim(name);
            if (name === "") {
                alert("bạn phải nhập tên !");
                return false;
            }

            var mobile = $('#txtMobile').val();

            var address = $('#txtAddress').val();
            var email = $('#txtEmail').val();
            if (email === "") {
                alert("Ban phai nhap email !");
                return false;
            }

            var content = $('#txtContent').val();


            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    mobile: mobile,
                    address: address,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi thành công');
                        contact.resetForm();
                    }

                }
            });


        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtMobile').val('');
        $('#txtAddress').val('');
        $('#txtEmail').val('');
        $('#txtContent').val('');
    }
}
contact.init();