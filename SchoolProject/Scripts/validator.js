function validateTeacher() {
    var teacherfname = document.getElementById("TeacherFname");
    var teacherfnamenull = document.getElementById("TeacherFname").value;
    var teacherlname = document.getElementById("TeacherLname");
    var teacherlnamenull = document.getElementById("TeacherLname").value;
    var teacherhiredate = document.getElementById("TeacherHireDate");
    var teacherhiredatenull = document.getElementById("TeacherHireDate").value;
    var teachersalary = document.getElementById("TeacherSalary");
    var teachersalarynull = document.getElementById("TeacherSalary").value;


    if (teacherfnamenull == "") {
        teacherfname.style.background = "red";
        return false;
    }

    if (teacherlnamenull == "") {
        teacherlname.style.background = "red";
        return false;
    }

    if (teacherhiredatenull == "") {
        teacherhiredate.style.background = "red";
        return false;
    }

    if (teachersalarynull == "") {
        teachersalary.style.background = "red";
        return false;
    }


    return true;

}