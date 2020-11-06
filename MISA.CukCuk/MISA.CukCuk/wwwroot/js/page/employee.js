$(document).ready(function () {


    var employee = new Employee();
    //customer.loadData();
   

})
class Employee extends Base {
    constructor() {
        super('employee');

    }
    getData() {
        this.Data = data;
    }
    /**
     * ham lay du lieuj theo id
     * author: HVM
     * date:21/10/2020
     * @param {any} employeeId
     */

    getDetailDataId(employeeId) {
        var self = this;
        $.ajax({

            url: "/api/employees/" + employeeId,
            method: "get",
            data: "",// tham số sẽ truyền qua body request
            contentType: "application/json",// 
            dataType: "",
            async: false

        }).done(function (response) {
            self.object = response;
            
        }).fail(function (response) {

        })
    }
    /**
     * 
     * 
     * 
     * */
    getByCode() {
        var self = this;
        $.ajax({
            url: "/api/employees/GetbyCode",
            method: "GET",
            async: false
        }).done(function (response) {
            var code = $("#modal tr td input[fieldname='employeeCode']").val(`NV${CommonJs.getItemCodeNumberIncrea(response)}`);
            self.employeeCode = `NV${CommonJs.getItemCodeNumberIncrea(response)}`;
            self.employeeID = "00000000-0000-0000-0000-000000000000";
            
        }).fail(response => {
            console.log(response)
        })
    }
    /**
     * ham xoa du lieuj theo id
     * author: HVM
     * date:21/10/2020
     * @param {any} employeeId
     */
    DeleteId(employeeId) {
        var self = this;
        $.ajax({

            url: "/api/employees/" + employeeId,
            method: "delete",
            data: "",// tham số sẽ truyền qua body request
            contentType: "application/json",// 
            dataType: "",
            async: false

        }).done(function (response) {
            //alert("Xóa thành công");
            self.loadData();
        }).fail(function (response) {

        })
    }
   

}
