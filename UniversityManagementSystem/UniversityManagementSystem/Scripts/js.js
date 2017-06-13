$(document).ready(function () {
    $("#DepartmentId").change(function () {
        var selectdepartmentId = $("#DepartmentId").val();
        $("#CourseTeacherId").empty();
        $("#CourseTeacherId").append('<option value=0> ' + "Select..." + '</option>');

        var json = { departmentId: selectdepartmentId };
        $.ajax({
            type: "POST",
            url: '@Url.Action("GetTeacherByDepartmentId", "Course")',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $.each(data, function (key, value) {
                    //alert(key);
                    $("#CourseTeacherId").append('<option value=' + value.Id + '>' + value.TeacherName + '</option>');
                });
            }
        });
    });
});