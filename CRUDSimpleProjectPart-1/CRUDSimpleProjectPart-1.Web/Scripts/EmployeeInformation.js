///<a href='/Employees/Delete" + row.EmployeeID + "' class='deleteButton'>Delete</a>
$(function () {

    $('.btn-info').unbind('click').bind('click', function () {

        var form = $(this).parents('form:first');



        var option = {
            url: "/Employees/Save",
            type: "POST",
            data: form.serialize(),
            //data: form.serialize(),
            //dataType: "html"
        };
        //$.ajax(option).done(function (resp) {
        //    $('#EmployeeList').html(resp);
        //});
        $.ajax(option).done(function () {
            LoadEmployeeInformation();
            //form.replaceWith('');

            form.data.replaceWith('');
        });
        //$.ajax(option).done(function () {
        //    alert('Saved Succesfully');
        //});


    });


});





$(document).ready(function () {
    debugger;
    $("#Delete").on("click", function () {
        var parent = $(this).parent().parent();
        $.ajax({
            type: "post",
            url: "/Employees/Delete",
            ajaxasync: true,
        success: function () {
            alert("success");
        },
        error: function (data) {
            alert(data.x);
        }
    });
});
    LoadEmployeeInformation();

});

function LoadEmployeeInformation() {

    $('#EmployeeList').html();

    $.ajax({

        url: '/Employees/GetAllEmployee',

        type: 'GET',

        dataType: 'json',

        success: function (d) {

            if (d.length > 0) {

                var $data = $('<table></table>').addClass('table table-striped table-responsive table-bordered table-hover');

                var header = " <thead><tr> <th>Name</th><th>City</th><th>Address</th><th>Action</th></tr></thead>";

                $data.append(header);

                $.each(d, function (i, row) {
                    var $row = $('<tr/>');
                    $row.append($('<td/>').html(row.Name));
                    $row.append($('<td/>').html(row.City));
                    $row.append($('<td/>').html(row.Address));
                    //tr += "<td><input type='button' class='editButton' onClick='editData(this)' value='Edit'></td>";
                    //tr += "<td><input type='button' class='deleteButton' onclick='deleteData(this)' value='Delete'></td>";
                    //$row.append($('<td/>').html("<input type='button' class='editButton' onClick='editData(this)' value='Edit'>"));
                    //$row.append($('<td/>').html("<input type='button' class='deleteButton' onClick='deleteData(this)' value='Delete'>"));

                    $row.append($('<td/>').html("<a href='/Employees/Edit/" + row.EmployeeID + "' class='popup'>Edit</a>&nbsp;|&nbsp;<a href='/Employees/Delete/" + row.EmployeeID + "' class='popup'>Delete</a>"));
                    $data.append($row);

                    //$row.replaceWith($('<tr/>'));
                   // Onclick = 'return false;'
                });

                $('#EmployeeList').html($data);



            }
            else {
                var $noData = $('<div/>').html('No Data Found!');
                $('#EmployeeList').html($noData);
            }





        },

        error: function () {
            alert('Error! Please Try Again :--');
        }


    });


}






$(function () {

    $('.deleteButton').unbind('click').bind('click', function() {


        var option = {
            url: "/Employees/Delete",
            type: "POST",
            data: id
            //dataType:"html"

        };

        $.ajax(option).done(function() {
            alert('data Deleted successfully');
        });


    });


});


function deleteData(object) {


    var option = {
        url: "/Employees/Delete",
        type: "POST",
        data: id
        //dataType:"html"

    };
    $.ajax(option).done(function () {
        alert('data Deleted successfully');
    });

  
}

//function deleteData(object) {
//    var button = $(object);
//    button.parent().parent().remove();
//}

