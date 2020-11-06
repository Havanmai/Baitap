class Base {
    constructor() {

        this.getData();
        this.loadData();
        this.inintEvent();

    }
    /**
    * các sự kiện
    * Author: HVM 29/09/2020
    * Edit : chức các sự kiện nút*/
    inintEvent() {

        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnMutil').click(this.btnMutilOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('.close').click(this.btnCloseOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#table').on('click', 'tr', this.rowonclick);
        $('#btnReload').click(this.btnReloadOnClick.bind(this));
        $('#btnChange').click(this.btnChangeOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('input[required]').blur(this.checkRequired);
        $('input[typeof]').blur(this.checkTypeOf);
        //$('#txtSalary').on('blur, focus, keyup', this.formatMoneyKeyup);
    }

    //#region laydulieu
    /**
    *   kế thừa
    * Author: HVM 29/09/2020
    * Edit : lấy data cho các lớp con  kế thừa*/
    getData() {
        this.Data = [];
    }
    /**
    *   lấy giá trị mã nhân viên lớn nhất
    * Author: HVM 22/10/2020
    * Edit : lấy data cho các lớp con  kế thừa*/
    getDataCode() {
        var sefl = this;
        $.ajax({
            url: "/api/employees/GetbyCode",
            method: "get",
            data: "",
            contentType: "application/json", 
            dataType: "",
            async: false
            

        }).done(function (response) {
            //console.log(response);
            self.entitycode = response;
        })
            .fail(function (response) {
            })

    }
    //#endregion laydulieu

    //#region Loaddulieu
    /**
     * Load dữ liệu 
     * Author: HVM 29/09/2020
     * Edit : load dữ liệu lên bảng*/

    loadData() {

        var getUrl = $("#table thead tr").attr('url');
       
        $.ajax({

            url: "/api/" + getUrl,
            method: "get",
            data: "",// tham số sẽ truyền qua body request
            contentType: "application/json",// 
            dataType: "",
            async: false,
            

        }).done(function (response) {

            try {
                // xoas trong bang truoc khi load du lieu
                $("#table tbody").empty();
                // đọc thông tin các cột dữ liệu
               
                var fields = $("#table thead th");
                var keyId = $('#table tbody tr.row-selected').attr('keyId');
                
                var data = this.Data;
                //lấy dữ liệu
                
                //đọc dữ liệu ra
                $.each(response, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $.each(fields, function (index, field) {
                        // binding du liệu
                        //TODO: them 1 truong chung voi ca thuoc tinh chung cua cac doi tuong de rut gon va tranh code xau
                        var fieldName = $(field).attr('fieldName');
                        var value = obj[fieldName];
                        if (fieldName == "postedDate" || fieldName == "dateOfBirth") {
                            var td = $(`<td align="center" >` + CommonJs.formatDate(value) + `</td>`);
                        } else if (fieldName == "debitAmount" || fieldName == "salary") {
                            var td = $(`<td align="right">` + CommonJs.fomartMoney(value) + `</td>`);
                        } 
                        else if (fieldName == "genderName") {
                            var td = $(`<td style="width:150px;" >` + value +`</td>`);
                        }
                        else if (fieldName == "email") {
                            var td = $(`<td style="width:300px;" >` + value + `</td>`);
                        }
                        else {
                            var td = $(`<td >` + value + `</td>`);
                        }
                        //var td = $(`<td >` + value + `</td>`);
                        $(tr).data('key', obj[Object.keys(obj)[0]]);
                        $(tr).append(td);
                    })
                    $('#table tbody').append(tr);
                })
            }
            catch (e) {
                console.log(e);
            }


        }).fail(function (response) {

        })


    }
        /*
        *Ham load gia tri phong ban vao select
        Author: HVM:
        Edit: Ham load gia tri phong ban vao select
        */
    loadDataDepartment() {

        $.ajax({

            url: "/api/Department",
            method: "get",
            data: "",// tham số sẽ truyền qua body request
            contentType: "application/json",// 
            dataType: ""

        }).done(function (response) {
            $.each(response, function (i, department) {
               
                $("#departmentName").append($('<option></option>').val(department.departmentID).text(department.departmentName));
            })
        }).fail(function (response) {

        })
    }
    /*
     *Ham load gia tri vi tri vao select
     Author: HVM:
     Edit: Ham load gia tri vi tri vao select
     */ 

    loadDataPosition() {

        $.ajax({

            url: "/api/Position",
            method: "get",
            data: "",// tham số sẽ truyền qua body request
            contentType: "application/json",// 
            dataType: ""

        }).done(function (response) {
            $.each(response, function (i, position) {
               
                $("#positionName").append($('<option></option>').val(position.positionID).text(position.positionName));
            })
        }).fail(function (response) {

        })
    }
    //#endregion 

   //#region nut du lieu

    /**Hien thi modal
     Author: HVM:
     Edit: Hien modal*/
    btnAddOnClick() {
        var self = this;
        var getUrl = $("#table thead tr").attr('url');
        $.ajax({
            url: "/api/employees/GetbyCode",
            method: "GET"
        }).done(function (response) {
            //debugger;
            $("#modal tr td input[fieldname='employeeCode']").val(`NV${CommonJs.getItemCodeNumberIncrea(response)}`)
        }).fail(function (response) {
            console.log(response)
        })
        self.showDetailModal();
       
        self.FormMode = "Add";
        $(self).focus;
       

    }

    /**tat modal
    Author: HVM:
    Edit: Tat modal*/
    btnCancelOnClick() {
        this.Refreshform();
        this.hideDetailModal();

    }
    /**tat modal
    Author: HVM:
    Edit: Tat modal*/
    btnCloseOnClick() {
        this.Refreshform();
        this.hideDetailModal();
    }
    /**hiển  modal
    Author: HVM:
    Edit:  bật modal*/
    showDetailModal() {
        $('.modal').show();
        $('.modal-content').show(function () {
            $("#txtEmployeeCode").focus();
        });
        this.loadDataDepartment();
        this.loadDataPosition();
       
    }
    /**tat modal
    Author: HVM:
    Edit: Tat modal*/
    hideDetailModal() {
        $('.modal').hide();
        $('.modal-content').hide();
    }



    /** ham nhan ban ban ghi 
     * author: HVM 05/10/2020
     * edit:them moi du lieu ban ghi duoc chonj
     * */


    /**save thoong tin ở bản trong modal
    Author: HVM:
    Edit: Tat modal*/
    btnSaveOnClick() {
        //validate thong tin nhap
        var inputRequieres = $('input[required]');
        //var checks = $("#modal tr td input[fieldname]");
        var IsValid = true; 
        var self = this;

        $.each(inputRequieres, function (index, input) {

            var valid = $(input).trigger("blur");
        

            if ((IsValid && valid.hasClass('required-error')) || (!IsValid && valid.hasClass('required-error')) || valid.hasClass('required-error')) {

              
                self.showWarning($("#modal tr td input[required]"), "Không được bỏ trống các ô bắt buộc nhập và phải nhập đúng định dạng của gmail");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            
                        });
                //#region Loi
                //$.each(checks, function (index, check) {

                //    var fieldName = $(check).attr('fieldName');

                //    if (fieldName == 'employeeName') {
                //        self.showWarning($("#txtEmployeeName"), "Họ và tên nhân viên không được bỏ trống");
                //        $("#btnOke").click(function () {
                //            $("#dialog-validate").hide();


                //        });
                //        //IsValid = false;
                        
                //    }

                //    //if (fieldName == 'employeeCode') {
                //    //    self.showWarning($("#modal tr td input[required]"), "Mã nhân viên không được bỏ trống");
                //    //    $("#btnOke").click(function () {
                //    //        $("#dialog-validate").hide();


                //    //    });
                //    //    //IsValid = false;
                //    //    //return false;
                //    //}
                //   else if (fieldName == 'email') {
                //        return false;
                //        self.showWarning($("#txtEmail"), "Email Nhân viên không được bỏ trống");
                //        $("#btnOke").click(function () {
                //            $("#dialog-validate").hide();

                //        });
                //        //IsValid = false;
                        
                //    }
                //    else if (fieldName == 'phoneNumber') {
                //        return false;
                //        self.showWarning($("#txtPhoneNumber"), "SDT Nhân viên không được bỏ trống");
                //        $("#btnOke").click(function () {
                //            $("#dialog-validate").hide();
                           
                //        });
                //        //IsValid = false;
                        
                //    }
                //});
                //#enregion
                IsValid = false;

           
               

            }
            else {

                IsValid = true;
            }

            if (!IsValid) {
                return false;
            }



        });
        
        // thu thap thong tin tren form
        if (IsValid) {
            var inputs = $('#modal tr td [fieldName]');
            var object = {};
            //var id = $('#table tbody tr.row-selected').attr('keyId');
            //var objectDetail = $('#table tbody tr.row-selected').data('data');

            $.each(inputs, function (index, input) {

                var fieldName = $(input).attr('fieldName');

                

                if (fieldName == 'salary') {

                    var value = parseFloat($(input).val());
                }
                else if (fieldName == 'workStatus') {
                    var value = parseFloat($(input).val());
                } else if (fieldName == 'gender') {
                    var value = parseFloat($(input).val());
                } else {
                    var value = $(input).val();
                }
                object[fieldName] = value;
                
            })


            if (self.FormMode == 'Add' ) {

                var getUrl = $("#table thead tr").attr('url');
                //alert('add');
                $.ajax({
                   
                    url: "/api/" + getUrl,
                    method: "POST",
                    data: JSON.stringify(object),
                    contentType: "application/json",
                    dataType: "json"
                
                }).done(function (response) {
                    //console.log(response);
                    
                   
                        self.showMsg("Thêm thành công thông tin nhân viên mới ");
                        $("#btnOkemsg").click(function () {
                            $("#dialog-msg").hide();
                            
                        })
                        self.loadData();

                        self.btnCloseOnClick();
                  
                        
                    
                }).fail(function (response) {
                    //console.log(response)
                    if (response.responseJSON.msg!= null) {
                        self.showWarning($("#modal tr td input[required]"), "Mã nhân viên đã tồn tại");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            $("#modal tr td input[required]").focus();
                        })
                    }
                    else {
                        self.showWarning($("#modal tr td input[required]"), "Hãy điền đầy đủ các thông tin vầ ngày tháng và số lương");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                        $("#modal tr td input[required]").focus();
                        })
                    }
                    })
                    
               
            } else if (self.FormMode == 'Edit' ) {
                self.selectId = $('#table tbody tr.row-selected').data('key');
                var getUrl = $("#table thead tr").attr('url');
                $.ajax({

                    url: "/api/" + getUrl + "/" + self.selectId,
                    method: "PUT",
                    data: JSON.stringify(object),
                    contentType: "application/json",
                    dataType: "json"
                }).done(function (res) {

                    self.showMsg("Sửa thành công thông tin nhân viên ");
                    $("#btnOkemsg").click(function () {
                        $("#dialog-msg").hide();

                    })
                    self.loadData();
                   
                    self.btnCloseOnClick();
                   
                }).fail(function (res) {
                    console.log(res)
                    if (res.responseJSON.msg != null) {
                        self.showWarning($("#modal tr td input[required]"), "Mã nhân viên đã tồn tại");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            $("#modal tr td input[required]").focus();
                        })
                    }
                    else {
                        self.showWarning($("#modal tr td input[required]"), "Hãy điền đầy đủ các thông tin vầ ngày tháng và số lương");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            $("#modal tr td input[required]").focus();
                        })
                    }
                })    

            }
            else if (self.FormMode == 'Mutil' ) {
                self.selectId = $('#table tbody tr.row-selected').data('key');
                var getUrl = $("#table thead tr").attr('url');
                //alert('add');
                $.ajax({
                    url: "/api/" + getUrl,
                    method: "POST",
                    data: JSON.stringify(object),
                    contentType: "application/json",
                    dataType: "json",
                    async: false
                }).done(function (res) {

                    self.showMsg("Nhân bản thành công thông tin nhân viên ");
                    $("#btnOkemsg").click(function () {
                        $("#dialog-msg").hide();

                    })
                    self.loadData();
                    self.btnCloseOnClick();
                }).fail(function (res) {
                    //console.log(res)
                    if (res.responseJSON.msg != null) {
                        self.showWarning($("#modal tr td input[required]"), "Mã nhân viên đã tồn tại");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            $("#modal tr td input[required]").focus();
                        })
                    }
                    else {
                        self.showWarning($("#modal tr td input[required]"), "Hãy điền đầy đủ các thông tin vầ ngày tháng và số lương");
                        $("#btnOke").click(function () {
                            $("#dialog-validate").hide();
                            $("#modal tr td input[required]").focus();
                        })
                    }
                })

            }
        }
       

    }

    /** ham cho nut sua
     * author: HVM 05/10/2020
     * edit:chi tiet nut sua thong tin trong bang content
     * */
    btnChangeOnClick() {
       
        var self = this;
        //console.log(self);
        self.FormMode = "Edit";
        // lay thong tin ban ghi da chon trong danh sach
        var recordSelected = $('#table tbody tr.row-selected');
        //self.selectId = recordSelected.data('data');
        self.selectId = recordSelected.data('key');
        // binding du lieu vao input tương ung tren form chi tiet:
        // building du lieu can luu
        self.getDetailDataId(self.selectId);
        var objectDetail = self.object;
        self.showDetailModal();

        var inputs = $('#modal tr td [fieldName]');


        $.each(inputs, function (index, input) {

            var fieldName = $(input).attr('fieldName');

            //if ($(input).attr('type')=='date') {
            //    input.value = CommonJs.formatDate(objectDetail[fieldName]);

            //}
            
            if (fieldName == "postedDate" || fieldName == "dateOfBirth" || fieldName == "identityDate" || fieldName == "joinDate") {
                input.value = CommonJs.formatDatel(objectDetail[fieldName]);
                debugger;
            } else if (fieldName == "debitAmount" || fieldName == "salary") {
                input.value = CommonJs.fomartMoney(objectDetail[fieldName]);
            }
            else {
                input.value = objectDetail[fieldName];
            }

        })



    }

    /** ham cho nut xoa
     * author: HVM 05/10/2020
     * edit:chi tiet nut xoa thong tin trong bang content
     * */
    btnDeleteOnClick() {
        // lay thong tin ban ghi da chon trong danh sach
        //$('#dialog-validate').show();
        var self = this;
        var recordSelected = $('#table tbody tr.row-selected');
        console.log(recordSelected);
        // lay du lieu thong tin cua danh sachs

        self.selectId = recordSelected.data('key');
        
        self.getDetailDataId(self.selectId);
        var objectDetail = self.object;
        self.showDelete("Bạn có chắc chắn muốn xóa nhân viên" + " " + objectDetail.employeeCode + " " + "không?");
        $('#btnOke1').click(function () {
            self.DeleteId(self.selectId);
            self.showMsg("Xóa thành công thông tin nhân viên ");
            $("#btnOkemsg").click(function () {
                $("#dialog-msg").hide();

            })
            $("#dialogDelete").hide();
        })
        $('#btnHuy').click(function () {
            $("#dialogDelete").hide();
            
        })

    }
    /** ham cho nut nap lai du lieu
     * author: HVM 05/10/2020
     * edit:chi tiet nut xoa thong tin trong bang content
     * */
    btnReloadOnClick() {
        this.loadData();

    }
    /**ham cho nut nhan ban du lieu
     * author: HVM 05/10/2020
     * edit:chi tiet nut xoa thong tin trong bang content
     * */
    btnMutilOnClick() {
        var self = this;
        self.FormMode = "Mutil";
        // lay thong tin ban ghi da chon trong danh sach
        var recordSelected = $('#table tbody tr.row-selected');
        //self.selectId = recordSelected.data('data');
        self.selectId = recordSelected.data('key');
        // binding du lieu vao input tương ung tren form chi tiet:
        // building du lieu can luu
        self.getDetailDataId(self.selectId);
        var objectDetail = self.object;
        console.log(objectDetail);
        self.getByCode();
        objectDetail.employeeCode = self.employeeCode;
        objectDetail.employeeId = self.employeeId;


        self.showDetailModal();

        var inputs = $('#modal tr td [fieldName]');


        $.each(inputs, function (index, input) {

            var fieldName = $(input).attr('fieldName');

            //if ($(input).attr('type')=='date') {
            //    input.value = CommonJs.formatDate(objectDetail[fieldName]);

            //}

            if (fieldName == "postedDate" || fieldName == "dateOfBirth" || fieldName == "identityDate" || fieldName == "joinDate") {
                input.value = CommonJs.formatDatel(objectDetail[fieldName]);
                
            } else if (fieldName == "debitAmount" || fieldName == "salary") {
                input.value = CommonJs.fomartMoney(objectDetail[fieldName]);
            }
            else {
                input.value = objectDetail[fieldName];
            }

        })

        
    }

 //#endregion


    //#region checkform
    /**
     * kiem tra du lieu rong
     * author: HVM 30/09/2020
     * Edit: kie tra trong du lieu khi nhap vao dialog modal*/

    checkRequired() {
        var value = this.value;
        if (!value || value == 0 || value == "" || !(value && value.trim())) {
            $(this).addClass('required-error');
            $(this).attr("title", "Ban phai nhap thong tin");


          
            return false;

        }
        else {
            $(this).removeClass('required-error');
            $(this).removeAttr("title", "Ban phai nhap thong tin");
            return true;
        }

    }
    /**
     * ham dinh dang tien te khi nhap
     * author: HVM 05/10/2020
     * edit: khi nhap luong vao trong input se tu dong dinh dang tiền tệ
     * */
    formatMoneyKeyup() {
        var value = parseInt(this.value.replaceAll('.',''));
        this.value = value.formatMoney();
    }

    /**
    * kiem tra du lieu truong email
    * author: HVM 05/10/2020
    * Edit: kiem tra trong du lieu khi nhap vao email cos ddungs dinh dang hay khong*/
    checkTypeOf() {
        var value = this.value;
        if (!CommonJs.isInvalidEmail(value)) {
            $(this).addClass('required-error');
            $(this).attr("title", "Ban phai nhap dung thong tin email");
            
            return;

        }
        else {
            $(this).removeClass('required-error');
            $(this).removeAttr("title", "Ban phai nhap dung thong tin email");

        }

    }
    /**chon hang
     * author: HVM 29/09/2020
     * edit: xac dinh hang duoc chon*/

    rowonclick() {
        $(this).siblings().removeClass('row-selected');
        $(this).addClass('row-selected');
    }


    /**show canh baos loi
     * author: HVM 29/09/2020
     * edit: show canh baos loi*/
    showWarning(item, content) {
        $("#dialog-validate #bodydaialog .notice-text").html(content)
        this.focusInput = item;
        $("#dialog-validate").show();
    }
    /**show canh baos xoa
     * author: HVM 29/09/2020
     * edit: show canh baos xoa*/
    showDelete( content) {
        $("#dialogDelete .bodydaialog .notice-text1").html(content)
       
        $("#dialogDelete").show();
    }
    /**show thong bao thanh comh
     * author: HVM 05/11/2020
     * edit: show canh baos xoa*/
    showMsg(content) {
        $("#dialog-msg .bodydaialog .notice-text").html(content)
        $("#dialog-msg").show();
    }

    /*
     
     
     */
    Refreshform() {
        $("#modal tr td [fieldname]").val('');
    }
    //#endregion
}



var data = [];
