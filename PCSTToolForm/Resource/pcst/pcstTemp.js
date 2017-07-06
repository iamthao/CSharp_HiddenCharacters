var app = angular.module('app', ['kendo.directives', 'ngAnimate', 'toaster']);

app.controller('PcstController', ['$q', '$scope', '$http', '$timeout', '$sce', 'toaster', function ($q, $scope, $http, $timeout, $sce, toaster) {

    var vm = this;
    vm.TaskActionParamViewModel = null;
    vm.RequestNo = null;
    vm.AssessmentPcsId = 0;
    vm.RequestId = null;
    vm.PcsVersion = null;
    vm.popupFormModified = false;
    vm.SectionList = [];
    vm.SectionItemSelected = null;
    vm.ContetHtml = null;
    vm.Sections = null;
    vm.AssessmentSectionQuestions = null;
    vm.Signature = null;
    vm.AssessmentName = "";
    var assessmentId = 0;
    vm.doBTemp = "";
    //This is from temp;
    ////disclosure form
    //vm.DisclosureForm = {};
    //vm.DisclosureForm.Member = {};
    //vm.DisclosureForm.Physician = {};
    //vm.DisclosureForm.OtherHealthcareProfessional = {};
    //vm.DisclosureForm.OtherAsListed = {};
    //vm.DisclosureForm.Providers = [];
    //vm.DisclosureForm.Guardian = {};
    //vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];

    //Bind datapicker Disclosure Form
    function bindDatePickerDisclosureForm() {

        $("#MemberDoB").kendoDatePicker({
            format: "MM/dd/yyyy",
            change: function () {
                var value = this.value();
                $("#MemberDoB").val(checkDateValid(value));
                vm.DisclosureForm.Member.DobStr = checkDateValid(value);
                vm.doBTemp = vm.DisclosureForm.Member.DobStr;
            }
        });
        $("#MemberDoB").kendoMaskedTextBox({
            mask: "00/00/0000",
            change: function () {
                var value = this.value();
                $("#MemberDoB").val(checkDateValid(value));
                vm.DisclosureForm.Member.DobStr = checkDateValid(value);
                vm.doBTemp = vm.DisclosureForm.Member.DobStr;
            }
        });

        $("#TheFollowingDateValue").kendoDatePicker({
            format: "MM/dd/yyyy",
            change: function () {
                var value = this.value();
                $("#TheFollowingDateValue").val(checkDateValid(value));
                vm.DisclosureForm.TheFollowingDateStr = checkDateValid(value);
            }
        });
        $("#TheFollowingDateValue").kendoMaskedTextBox({
            mask: "00/00/0000",
            change: function () {
                var value = this.value();
                $("#TheFollowingDateValue").val(checkDateValid(value));
                vm.DisclosureForm.TheFollowingDateStr = checkDateValid(value);
            }
        });

        $("#DateSign").kendoDatePicker({
            format: "MM/dd/yyyy",
            change: function () {
                var value = this.value();
                $("#DateSign").val(checkDateValid(value));
                vm.DisclosureForm.DateSignedStr = checkDateValid(value);
            }
        });
        $("#DateSign").kendoMaskedTextBox({
            mask: "00/00/0000",
            change: function () {
                var value = this.value();
                $("#DateSign").val(checkDateValid(value));
                vm.DisclosureForm.DateSignedStr = checkDateValid(value);
            }
        });

    }
    bindDatePickerDisclosureForm();

    function subMarkPhone() {
        var format = '(999) 999-9999';
        $("#PhysicianPhone").mask(format);
        $("#PhysicianFax").mask(format);
        $("#OtherHealthcareProfessionalPhone").mask(format);
        $("#OtherHealthcareProfessionalFax").mask(format);
    };
    subMarkPhone();
    function returnNowStr() {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd
        }

        if (mm < 10) {
            mm = '0' + mm
        }
        return mm + '/' + dd + '/' + yyyy;
    }
    function checkDateValid(value) {
        var valueField = value;
        if (value == null || value == undefined) {
            valueField = "";
        } else {
            valueField = kendo.toString(value, 'd');
            var comp = valueField.split('/');
            var m = parseInt(comp[0]) > 9 ? parseInt(comp[0]) : "0" + parseInt(comp[0]);
            var d = parseInt(comp[1]) > 9 ? parseInt(comp[1]) : "0" + parseInt(comp[1]);
            var y = parseInt(comp[2]) > 9 ? parseInt(comp[2]) : "0" + parseInt(comp[2]);
            var date = new Date(y, m - 1, d);
            if (date.getFullYear() != y || date.getMonth() + 1 != m || date.getDate() != d) {
                valueField = "";
            } else {
                valueField = m + "/" + d + "/" + y;
            }
        }
        return valueField;
    }

    vm.representativeSignClear = function () {
        vm.representativeSign.clear();
    }

    vm.assessorSignClear = function () {
        vm.assessorSign.clear();
    }

    $scope.Test = function () {
        //console.log(vm.GuardianSignatureIsEmpty);
        //console.log(vm.guardianSignature.isEmpty());
        //console.log(vm.guardianSignature.toDataURL());
        vm.DisclosureForm.Member.DobStr = vm.doBTemp;
        //console.log(vm.DisclosureForm.Member);
        //console.log(vm.doBTemp);
    }
    //
    function activate() {
        $(".loader").fadeIn();
        vm.widthCanvasRep = $("#AssessorName").width();
        vm.widthCanvasAss = $("#AssessorName").width();
        $timeout(function () {
            vm.widthCanvasMem = $("#PhysicianName").width() * 1.5;
            vm.widthCanvasGua = $("#PhysicianName").width() * 1.5;
        });



        $http.get('http://localhost:9000/api/Assessment?id=' + assessmentId).then(function (result) {
            if (result && result.data) {
                vm.RequestNo = result.data.RequestNo;
                vm.AssessmentPcsId = result.data.AssessmentPcsId;
                vm.AssessmentName = result.data.AssessmentName;
                vm.PcsVersion = result.data.PcsVersion;
                vm.DisclosureForm = result.data.DisclosureFormVo;
                //console.log(result.data)
                $timeout(function () {
                    if (vm.DisclosureForm != null) {
                        if (vm.DisclosureForm.Guardian != undefined && vm.DisclosureForm.Guardian != null) {
                            if (vm.DisclosureForm.Guardian.Signature != undefined && vm.DisclosureForm.Guardian.Signature != null) {
                                vm.guardianSignature.fromDataURL(vm.DisclosureForm.Guardian.Signature);
                                vm.GuardianSignatureIsEmpty = false;
                                vm.IsCheckGuardianSignature = 1;
                            } else {
                                vm.GuardianSignatureIsEmpty = true;
                            }
                        }
                        else {
                            vm.DisclosureForm.Guardian = {};
                        }
                        if (vm.DisclosureForm.Member != undefined && vm.DisclosureForm.Member != null) {
                            if (vm.DisclosureForm.Member.Signature != undefined && vm.DisclosureForm.Member.Signature != null) {
                                vm.memberSignature.fromDataURL(vm.DisclosureForm.Member.Signature);
                            }
                            if (vm.DisclosureForm.Member.DobStr != undefined && vm.DisclosureForm.Member.DobStr != null) {
                                //$("#MemberDoB").val(vm.DisclosureForm.Member.DobStr == "01/01/0001" ? "" : vm.DisclosureForm.Member.DobStr);
                                $("#MemberDoB").val(vm.DisclosureForm.Member.DobStr);
                                vm.doBTemp = vm.DisclosureForm.Member.DobStr;
                            }

                        } else {
                            vm.DisclosureForm.Member = {};
                        }

                        if (vm.DisclosureForm.TheFollowingDateStr != undefined && vm.DisclosureForm.TheFollowingDateStr != null) {
                            //$("#TheFollowingDateValue").val(vm.DisclosureForm.TheFollowingDateStr == "01/01/0001" ? "" : vm.DisclosureForm.TheFollowingDateStr);
                            $("#TheFollowingDateValue").val(vm.DisclosureForm.TheFollowingDateStr);
                        }

                        if (vm.DisclosureForm.DateSignedStr != undefined && vm.DisclosureForm.DateSignedStr != null) {
                            //$("#DateSign").val(vm.DisclosureForm.DateSignedStr == "01/01/0001" ? "" : vm.DisclosureForm.DateSignedStr);
                            $("#DateSign").val(vm.DisclosureForm.DateSignedStr);
                        } else {
                            var now =
                                $("#DateSign").val(returnNowStr());
                            vm.DisclosureForm.DateSignedStr = returnNowStr();
                        }

                        if (vm.DisclosureForm.OtherAsListed != undefined && vm.DisclosureForm.OtherAsListed != null
                            && vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed != undefined && vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed != null) {
                            initOtherAsListed();
                        } else {
                            vm.DisclosureForm.OtherAsListed = {};
                            vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
                        }


                        if (vm.DisclosureForm.IsHasProviderAgency != undefined && vm.DisclosureForm.IsHasProviderAgency != null) {
                            initProvider();
                        }

                        if (vm.DisclosureForm.OtherHealthcareProfessional != undefined && vm.DisclosureForm.OtherHealthcareProfessional != null) {

                        } else {
                            vm.DisclosureForm.OtherHealthcareProfessional = {};
                        }

                        if (vm.DisclosureForm.Physician != undefined && vm.DisclosureForm.Physician != null) {

                        } else {
                            vm.DisclosureForm.Physician = {};
                            vm.DisclosureForm.Physician.IsHasPhysician = false;
                        }

                        vm.guardianSignature.onBegin = function () {
                            vm.IsCheckGuardianSignature = 2;
                            vm.GuardianSignatureIsEmpty = false;
                        }

                        //vm.memberSignature.onBegin = function () {
                        //    vm.hiddenMemberSign = 2;
                        //}

                    } else {
                        vm.DisclosureForm = {};
                        vm.DisclosureForm.Member = {};
                        vm.DisclosureForm.Physician = {};
                        vm.DisclosureForm.OtherHealthcareProfessional = {};
                        vm.DisclosureForm.OtherAsListed = {};
                        vm.DisclosureForm.Guardian = {};
                        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
                    }
                    bindingTextBoxOtherAsListed();

                }, 500);


                //vm.representativeSign.fromDataURL(vm.DisclosureForm.RepresentativeSign);
                //vm.assessorSign.fromDataURL(vm.DisclosureForm.AssessorSign);

                handleSectionList(result.data);
                $(".loader").fadeOut();
            }
        });
        installGridProvider();
        installGridPhysician();

    }

    activate();

    // start disclose Form


    function canRemove(el) {
        var result = true;
        el.find('div input').each(function () {
            var val = $(this).val();
            if (val != undefined && val != "") {
                result = false;
            }
        });
        return result;
    }
    vm.guardianSignatureClear = function () {
        vm.guardianSignature.clear();
        vm.IsCheckGuardianSignature = 0;
        vm.GuardianSignatureIsEmpty = true;
    }

    vm.memberSignatureClear = function () {
        vm.memberSignature.clear();
        vm.hiddenMemberSign = 0;
    }

    function convertToOtherAsListed() {
        $('#tableOtherAsListed').find('tr.list').each(function () {
            var obj = { Name: "", Relationship: "" };
            $(this).find('td div input').each(function () {
                if ($(this).attr("name").indexOf("Field02") >= 0) {
                    obj.Relationship = $(this).val();
                } else {
                    obj.Name = $(this).val();
                }
            });

            vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.push(obj);
        });
    }
    function bindingTextBoxOtherAsListed() {
        $("#tableOtherAsListed input").each(function () {
            $(this).bind("blur", function () {
                var val = $(this).val();
                var tr = $(this).parent().parent().parent().parent();
                if (val != undefined && val != "") {
                    if (tr.find('span.red').length == 0) {
                        tr.find('div label').append("<span class='red' style='line-height: 0px'>*</span>");
                        tr.find('div label').removeClass("norequired");
                    }
                    appendLineInOtherAsListed(tr);
                } else {
                    removeLineInListDiscloseForm(tr);
                }
            });
        });
    }
    function removeLineInListDiscloseForm(el) {
        if (el.parent().find('tr.list').length > 1) {
            var lastId = el.parent().find('tr.list:last-child input').attr('id');
            var thisId = el.find('input').attr('id');
            if (lastId !== thisId) {
                if (canRemove(el) == true) {
                    el.remove();
                }
            }
        }

        if ($('#OtherAsListedDisclosureForm').find('tr.list').length == 1) {
            var tr = $('#OtherAsListedDisclosureForm').find('tr.list');
            if (tr.find('span.red').length == 0) {
                tr.find('div label').append("<span class='red' style='line-height: 0px'>*</span>");
                tr.find('div label').removeClass("norequired");
            }
        }
    }
    function initProvider() {
        vm.DisclosureForm.Providers.forEach(function (item) {
            if (item.Order == 1) {
                vm.AgencyId = item.Mpi;
                vm.AgencyName = item.Name;
            }
            else if (item.Order == 2) {
                vm.Agency2Id = item.Mpi;
                vm.Agency2Name = item.Name;
            }
            else if (item.Order == 3) {
                vm.Agency3Id = item.Mpi;
                vm.Agency3Name = item.Name;
            }
        });

    }
    function initOtherAsListed() {
        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.forEach(function (item) {
            var tr = $('#tableOtherAsListed').find('tr.list').last();
            tr.find('input').each(function () {
                if ($(this).attr("name").indexOf("Field02") >= 0) {
                    $(this).val(item.Relationship);
                } else {
                    $(this).val(item.Name);
                }
            });
            if (tr.find('span.red').length == 0) {
                tr.find('div label').append("<span class='red' style='line-height: 0px'>*</span>");
                tr.find('div label').removeClass("norequired");
            }
            appendLineInOtherAsListed(tr);
        });
    }
    function setNextIndexIdInListDiscloseForm(idAttr, i, val) {

        var slit = idAttr.split('-');
        if (slit.length > i) {
            slit[i] = (val + 1) + '';
        }
        return slit.join('-');
    }
    function getIndexIdInListDiscloseForm(idAttr, i) {
        var slit = idAttr.split('-');
        if (slit.length > i) {
            return parseInt(slit[i]);
        }
    }
    function appendLineInOtherAsListed(el) {
        if (el.parent().find('tr.list').length <= 20) {
            var lastId = el.parent().find('tr.list').last().find('input').attr('id');
            var thisId = el.find('input').attr('id');
            if (lastId === thisId) {
                var copyEl = $('<tr class="list"></tr>').html(el.html());
                copyEl.find('td div input').each(function () {
                    var i = getIndexIdInListDiscloseForm(lastId, 2);
                    var curId = '';
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInListDiscloseForm(curId, 2, i));
                    $(this).attr('name', setNextIndexIdInListDiscloseForm(curId, 2, i));
                    $(this).html("");
                });
                copyEl.find('td div label').each(function () {
                    $(this).addClass('norequired');
                });
                copyEl.find("span").remove();
                if (el.data('indexappend') != undefined) {
                    el.parent().parent().append('<tr class="list" data-indexappend="' + el.data('indexappend') + '">' + copyEl.html().replace('display: none;', '') + '</tr>');
                } else {
                    el.parent().parent().append('<tr class="list">' + copyEl.html() + '</tr>');
                }

                bindingTextBoxOtherAsListed();
            }
        }
    }

    vm.GuardianSignatureIsEmpty = true;
    vm.IsCheckGuardianSignature = 0;
    vm.GuardianIsRequired = false;

    var checkGuardianHadBeenFilleds = function () {
        if (vm.DisclosureForm.Guardian != null) {
            if ((vm.DisclosureForm.Guardian.Name != null && vm.DisclosureForm.Guardian.Name != undefined && vm.DisclosureForm.Guardian.Name != "")
                || (vm.DisclosureForm.Guardian.Relationship != null && vm.DisclosureForm.Guardian.Relationship != undefined && vm.DisclosureForm.Guardian.Relationship != "")
                || !vm.GuardianSignatureIsEmpty) {
                return true;
            }
        } else {
            return false;
        }

    }

    $scope.$watch('vm.IsCheckGuardianSignature', function (n, o) {
        if (n != o) {
            vm.GuardianIsRequired = checkGuardianHadBeenFilleds();
        }
    });
    $scope.$watch('vm.DisclosureForm.Guardian.Name', function (n, o) {
        if (n != o) {
            vm.GuardianIsRequired = checkGuardianHadBeenFilleds();
        }
    });
    $scope.$watch('vm.DisclosureForm.Guardian.Relationship', function (n, o) {
        if (n != o) {
            vm.GuardianIsRequired = checkGuardianHadBeenFilleds();
        }
    });

    $scope.$watch("vm.DisclosureForm.IsOnTheFollowingDate", function (n, o) {
        if (n == true) {
            $('#TheFollowingDateValue').removeAttr('disabled');
            $("#TheFollowingDateValue").data("kendoDatePicker").readonly(false);
        } else {
            $('#TheFollowingDateValue').attr('disabled', 'disabled');
            $("#TheFollowingDateValue").data("kendoDatePicker").readonly(true);
        }
    });

    $scope.$watch("vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed", function (n, o) {
        if (n) {
            if ($('#OtherAsListedDisclosureForm div label').has('span').length == 0) {
                $('#OtherAsListedDisclosureForm div label:not(.norequired)').append("<span class='red' style='line-height: 0px'>*</span>");
            }

            $('#OtherAsListedDisclosureForm div input').each(function () {
                $(this).removeAttr('disabled');
            });
        } else {
            $('#OtherAsListedDisclosureForm div label span').remove();
            $('#OtherAsListedDisclosureForm div input').each(function () {
                $(this).attr('disabled', 'disabled');
            });
        }
    });

    $scope.$watch("vm.DisclosureForm.IsHasProviderAgency", function (n, o) {
        if (n) {
            if ($('#providersDisclosureForm div label:not(.norequired)').has('span').length == 0) {
                $('#providersDisclosureForm div label:not(.norequired)').append("<span class='red'>*</span>");
            }
            $('#providersDisclosureForm input[ng-model]').each(function () {
                $(this).removeAttr('disabled');
                $(this).parent().find('a').removeAttr("style");
            });
        } else {
            $('#providersDisclosureForm div label:not(.norequired) span').remove();
            $('#providersDisclosureForm input[ng-model]').each(function () {
                $(this).attr('disabled', 'disabled');
                $(this).parent().find('a').css({ "pointer-events": "none", "cursor": "default" });
            });
        }
    });

    var agency1TextOld = "";
    $("#Agency1").blur(function () {
        var newText = $("#Agency1").val();
        if (newText.trim() != '') {
            agency1TextOld = newText;
            $http.post("http://localhost:9000/api/Provider/GetProviderFromName", JSON.stringify(Base64.encode(newText))).then(function (result) {
                if (result.data != undefined && result.data.Id != null) {
                    $scope.OrderProvider = 1;
                    setAgainProvider(result.data);
                } else {
                    $("#Agency1").val("");
                    var error = [];
                    error.push({ MessageError: "Provider not found." });
                    vm.ShowErrorInValid(error);
                }
            });
        }
    });

    var agency2TextOld = "";
    $("#Agency2").blur(function () {
        var newText = $("#Agency2").val();
        if (newText.trim() != '') {
            agency2TextOld = newText;
            $http.post("http://localhost:9000/api/Provider/GetProviderFromName", JSON.stringify(Base64.encode(newText))).then(function (result) {
                if (result.data != undefined && result.data.Id != null) {
                    $scope.OrderProvider = 2;
                    setAgainProvider(result.data);
                } else {
                    $("#Agency2").val("");
                    var error = [];
                    error.push({ MessageError: "Provider not found." });
                    vm.ShowErrorInValid(error);
                }
            });
        }
    });

    var agency3TextOld = "";
    $("#Agency3").blur(function () {
        var newText = $("#Agency3").val();
        if (newText.trim() != '') {
            agency3TextOld = newText;
            $http.post("http://localhost:9000/api/Provider/GetProviderFromName", JSON.stringify(Base64.encode(newText))).then(function (result) {
                if (result.data != undefined && result.data.Id != null) {
                    $scope.OrderProvider = 3;
                    setAgainProvider(result.data);
                } else {
                    $("#Agency3").val("");
                    var error = [];
                    error.push({ MessageError: "Provider not found." });
                    vm.ShowErrorInValid(error);
                }
            });
        }
    });

    function setAgainProvider(item) {

        if ($scope.OrderProvider == 1) {
            vm.AgencyId = item.Id;
            vm.AgencyName = item.Name;

            if (vm.Agency2Id == item.Id) {
                vm.Agency2Id = null;
                vm.Agency2Name = "";
                agency2TextOld = "";
            }

            if (vm.Agency3Id == item.Id) {
                vm.Agency3Id = null;
                vm.Agency3Name = "";
                agency3TextOld = "";
            }
        }
        else if ($scope.OrderProvider == 2) {
            vm.Agency2Id = item.Id;
            vm.Agency2Name = item.Name;

            if (vm.AgencyId == item.Id) {
                vm.AgencyId = null;
                vm.AgencyName = "";
                agency1TextOld = "";
            }

            if (vm.Agency3Id == item.Id) {
                vm.Agency3Id = null;
                vm.Agency3Name = "";
                agency3TextOld = "";
            }
        }
        else {
            vm.Agency3Id = item.Id;
            vm.Agency3Name = item.Name;

            if (vm.AgencyId == item.Id) {
                vm.AgencyId = null;
                vm.AgencyName = "";
                agency1TextOld = "";
            }

            if (vm.Agency2Id == item.Id) {
                vm.Agency2Id = null;
                vm.Agency2Name = "";
                agency2TextOld = "";
            }
        }
    }

    function installGridProvider() {
        $scope.OrderProvider = 1;
        $scope.openProvider = function (order) {
            $scope.OrderProvider = order;
            vm.popupInstallSelectProvider.open();
        }

        vm.returnSelectProvider = function (item) {
            setAgainProvider(item);
            vm.popupInstallSelectProvider.close();
        };

        vm.clearTextProvider = function () {
            2
            vm.Name = "";
            vm.MPI = "";
            vm.NPI = "";
            vm.dataSourceProvider.read();
        }

        vm.searchProvider = function (e) {
            if (e == undefined || e.keyCode === 13) {
                vm.dataSourceProvider._skip = 0;
                vm.dataSourceProvider.read();
            }
        }

        var schemaFieldsProvider = {
            Id: { editable: false },
            Name: { editable: false }
        };
        vm.dataSourceProvider = new kendo.data.DataSource({
            transport: {
                read: {
                    url: "http://localhost:9000/api/Provider",
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8'
                },
                parameterMap: function (options, operation) {
                    if (operation === "read") {
                        var result = {
                            pageSize: options.pageSize,
                            skip: options.skip,
                            take: options.take,
                            Npi: vm.NPI,
                            Mpi: vm.MPI,
                            AgencyName: vm.Name,
                        };
                        return "queryInfo=" + Base64.encode(angular.toJson(result));
                    }
                }
            },

            serverPaging: true,
            serverSorting: true,
            pageSize: 10,
            batch: true,
            emptyMsg: 'No Record',
            table: "#providerAdvancedSearchGrid",
            schema: {
                model: {
                    id: "Id",
                    fields: schemaFieldsProvider
                },
                data: "Data",
                total: "TotalRowCount"
            }
        });
        vm.gridOptionsProvider = {

            dataSource: vm.dataSourceProvider,
            pageable: {
                refresh: true,
            },
            height: 330,
            dataBound: function () {
                $('[data-toggle="tooltip"]').tooltip({
                    container: 'body',
                    html: true
                });
            },
            autoBind: false,
            columns: [
               {
                   field: "Name",
                   title: "Agency Name",
                   width: "100px"
               }, {
                   field: "Mpi",
                   title: "MPI",
                   width: "60px"
               }, {
                   field: "Npi",
                   title: "NPI",
                   width: "60px"
               }, {
                   field: "Email",
                   title: "Email",
                   width: "80px"
               }, {
                   field: "PhoneInFormat",
                   title: "Phone",
                   width: "60px"
               }, {
                   field: "FullAddress",
                   title: "Address",
                   width: "150px"
               }
                , {
                    field: "",
                    title: "",
                    width: "50px",
                    template: "<button ng-click='vm.returnSelectProvider(dataItem)' class='btn btn-default btn-alt' data-toggle='tooltip' data-placement='bottom' title='Select'><i class='fa fa-hand-o-left'></i></button>"
                }
            ]
        };
    }
    // end disclose Form

    function handleSectionList(data) {
        if (data.Sections != null && data.Sections.length > 0) {
            vm.Sections = data.Sections;
            vm.AssessmentSectionQuestions = data.AssessmentSectionQuestions;
            for (var i = 0; i < data.Sections.length; i++) {
                if (data.Sections[i].Order != 0) {
                    vm.SectionList.push({ Order: data.Sections[i].Order, Name: data.Sections[i].Name });
                }
            }
            vm.SectionItemSelected = vm.SectionList[0];
            vm.ContetHtml = getContentHtmlByOrder(vm.SectionList[0].Order);

            callBindForNextSection();
            bindEventDoubleClick(data);
            $scope.$watch('vm.SectionItemSelected', function (nval, oval) {
                if (!angular.equals(nval, oval)) {
                    $timeout(function () {
                        $('#content-section-div').scrollTop(0);
                        callSaveNextSection(oval, true);
                        vm.saveWhenNextSection().then(function (resul) { });
                        vm.ContetHtml = getContentHtmlByOrder(nval.Order);
                        bindEventDoubleClick(data);
                        callBindForNextSection();
                        vm.SetShowNextSection();
                    });
                }

            }, true);
        }
    }

    function bindEventDoubleClick(data) {
        $timeout(function () {
            $('table#content-section input:radio').not("tr.list").unbind('click');
            $('table#content-section #Order5-Answer input:radio').removeAttr("disabled");//Thao
            $('table#content-section #Order10-Field01-Highlight input:text').removeAttr("disabled");//Thao
            $('table#content-section #Order13-Field01-Highlight input:text').removeAttr("disabled");//Thao
            var value = '';
            $('table#content-section input:radio').not("tr.list").bind('click', function (e) {

                if ($(this).attr("value") === value) {
                    if ($(this).attr("checked") == 'checked') {
                        $(this).removeAttr('checked');
                        $(this).prop('checked', false);
                    } else {
                        $(this).attr('checked', 'checked');
                        $(this).prop('checked', true);
                    }
                } else {
                    $('table#content-section input[name=' + $(this).attr('name') + ']').removeAttr('checked');
                    value = $(this).attr("value");
                    $(this).attr('checked', 'checked');
                    $(this).prop('checked', true);
                }
            });
            $('table#content-section input:text').not("tr.list input:text").unbind('blur');
            $('table#content-section input:text').not("tr.list input:text").bind('blur', function (e) {
                var ids = $(this).attr('id').split('-');
                if (ids.length === 4) {
                    checkAndAppend($(this).attr('id'));
                } else {
                    $(this).attr('value', $(this).val());
                }
            });
            $('table#content-section input:checkbox').not("tr.list").unbind('click');
            $('table#content-section input:checkbox').not("tr.list").bind('click', function (e) {
                if ($(this).prop('checked')) {
                    $(this).attr('checked', 'checked');
                } else {
                    $(this).removeAttr('checked');
                }
            });
            bindEventPhone();
            bindEventDate();
            bindEventHour();
            bindEventNumber();
            bindEventSignature();
            bindingSelect();
            handleGenerate();
            bindEventLookup();
            handleNonGenerate();
            bindingHideWHenCheckNone();
            bindingTextAreaChange();
            bindingDisableDMEAndOption();
            $('table#content-section input.date-pick').each(function () {
                bindDatepicker($(this).attr('id'));
            });
            $('table#content-section input.physician').each(function () {
                bindEventSelectPhysician();
            });

            bindingDivContentLength();
        });
    }

    /// Nghiep -----------------------------------------
    function bindingDivContentLength() {
        var maxlength = 1000;

        //$('table#content-section .inputdiv').unbind('keydown');
        //$('table#content-section .inputdiv').bind('keydown', function (e) {
        //    if ($(this).text().length === maxlength && event.keyCode != 8) /*delete*/ {
        //        event.preventDefault();
        //    }
        //    var editableDiv = document.getElementById($(this).attr('id'));
        //    cursorManager.setEndOfContenteditable(editableDiv);
        //});

        //$('table#content-section .inputdiv').unbind('keyup');
        //$('table#content-section .inputdiv').bind('keyup', function (e) {
        //    var lengthText = $(this).text().length;
        //    if (lengthText >= maxlength) {
        //        var str = $(this).text().substring(0, maxlength);
        //        $(this).text(str)

        //        //console.log('keyup', $(this).text().substring(0, maxlength))
        //    }
        //    var editableDiv = document.getElementById($(this).attr('id'));
        //    cursorManager.setEndOfContenteditable(editableDiv);
        //});
        //$('table#content-section .inputdiv').unbind('mousedown');
        //$('table#content-section .inputdiv').bind('mousedown', function (e) {
        //    var lengthText = $(this).text().length;
        //    if (lengthText >= maxlength) {
        //        var str = $(this).text().substring(0, maxlength);
        //        $(this).text(str)
        //    }
        //    var editableDiv = document.getElementById($(this).attr('id'));
        //    cursorManager.setEndOfContenteditable(editableDiv);
        //});

        //$('table#content-section .inputdiv').unbind('paste');
        //$('table#content-section .inputdiv').bind('paste', function (e) {
        //    var lengthText = $(this).text().length;
        //    if (lengthText >= maxlength) {
        //        e.preventDefault();
        //        //if (event != undefined) {
        //        //    event.preventDefault();
        //        //}
        //    } else {
        //        var lengthAllow = maxlength - lengthText;
        //        var textFull = $(this).text() + e.originalEvent.clipboardData.getData('text').substring(0, lengthAllow);
        //        $(this).text('');

        //        $(this).focus();
        //        pasteHtmlAtCaret(textFull);
        //        e.preventDefault();

        //        //if (event != undefined) {
        //        //    event.preventDefault();
        //        //}


        //    }
        //    // console.log($(this).text(), $(this).html(), $(this).attr('id'))          
        //});
    };
    (function (cursorManager) {

        //From: http://www.w3.org/TR/html-markup/syntax.html#syntax-elements
        var voidNodeTags = ['AREA', 'BASE', 'BR', 'COL', 'EMBED', 'HR', 'IMG', 'INPUT', 'KEYGEN', 'LINK', 'MENUITEM', 'META', 'PARAM', 'SOURCE', 'TRACK', 'WBR', 'BASEFONT', 'BGSOUND', 'FRAME', 'ISINDEX'];

        //From: https://stackoverflow.com/questions/237104/array-containsobj-in-javascript
        Array.prototype.contains = function (obj) {
            var i = this.length;
            while (i--) {
                if (this[i] === obj) {
                    return true;
                }
            }
            return false;
        }

        //Basic idea from: https://stackoverflow.com/questions/19790442/test-if-an-element-can-contain-text
        function canContainText(node) {
            if (node.nodeType == 1) { //is an element node
                return !voidNodeTags.contains(node.nodeName);
            } else { //is not an element node
                return false;
            }
        };

        function getLastChildElement(el) {
            var lc = el.lastChild;
            while (lc && lc.nodeType != 1) {
                if (lc.previousSibling)
                    lc = lc.previousSibling;
                else
                    break;
            }
            return lc;
        }

        //Based on Nico Burns's answer
        cursorManager.setEndOfContenteditable = function (contentEditableElement) {

            while (getLastChildElement(contentEditableElement) &&
                  canContainText(getLastChildElement(contentEditableElement))) {
                contentEditableElement = getLastChildElement(contentEditableElement);
            }

            var range, selection;
            if (document.createRange)//Firefox, Chrome, Opera, Safari, IE 9+
            {
                range = document.createRange();//Create a range (a range is a like the selection but invisible)
                range.selectNodeContents(contentEditableElement);//Select the entire contents of the element with the range
                range.collapse(false);//collapse the range to the end point. false means collapse to end rather than the start
                selection = window.getSelection();//get the selection object (allows you to change selection)
                selection.removeAllRanges();//remove any selections already made
                selection.addRange(range);//make the range you have just created the visible selection
            }
            else if (document.selection)//IE 8 and lower
            {
                range = document.body.createTextRange();//Create a range (a range is a like the selection but invisible)
                range.moveToElementText(contentEditableElement);//Select the entire contents of the element with the range
                range.collapse(false);//collapse the range to the end point. false means collapse to end rather than the start
                range.select();//Select the range (make it the visible selection
            }
        }

    }(window.cursorManager = window.cursorManager || {}));

    function pasteHtmlAtCaret(html) {
        var sel, range;
        if (window.getSelection) {
            // IE9 and non-IE
            sel = window.getSelection();
            if (sel.getRangeAt && sel.rangeCount) {
                range = sel.getRangeAt(0);
                range.deleteContents();

                // Range.createContextualFragment() would be useful here but is
                // non-standard and not supported in all browsers (IE9, for one)
                var el = document.createElement("div");
                el.innerHTML = html;
                var frag = document.createDocumentFragment(), node, lastNode;
                while ((node = el.firstChild)) {
                    lastNode = frag.appendChild(node);
                }
                range.insertNode(frag);

                // Preserve the selection
                if (lastNode) {
                    range = range.cloneRange();
                    range.setStartAfter(lastNode);
                    range.collapse(true);
                    sel.removeAllRanges();
                    sel.addRange(range);
                }
            }
        } else if (document.selection && document.selection.type != "Control") {
            // IE < 9
            document.selection.createRange().pasteHTML(html);
        }
    }

    $scope.saveToList = false;
    setInterval(function () {
        vm.CheckDataChange();
    }, 300000);

    vm.dataAssessmentSectionQuestionsOldJson = null;
    vm.CheckDataChange = function () {
        vm.dataAssessmentSectionQuestionsOldJson = JSON.stringify(vm.AssessmentSectionQuestions);
        callSaveNextSection(vm.SectionItemSelected);
        setTimeout(function () {
            if ($scope.saveToList) {
                $scope.saveToList = false;
                vm.saveWhenNextSection();
                return;
            }
            else if (vm.AssessmentSectionQuestions != undefined && vm.AssessmentSectionQuestions != null) {
                if (vm.dataAssessmentSectionQuestionsOldJson != JSON.stringify(vm.AssessmentSectionQuestions)) {
                    vm.saveWhenNextSection();
                    return;
                }
            }
        }, 5000);
    }

    function genBindingDisableDMEAndOptionNone(i) {
        //--None Part A
        $('.Order' + i + '-Current-None').unbind('change');
        $('.Order' + i + '-Current-None').bind('change', function (e) {
            if ($(this).is(':checked')) {
                $('#Order' + i + '-Current-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
            } else {
                $('#Order' + i + '-Current-Disabled input:checkbox').each(function () {
                    $(this).prop('disabled', false);
                });
            }
        });

        setTimeout(function () {
            if ($('.Order' + i + '-Current-None').is(':checked')) {
                $('#Order' + i + '-Current-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
            }
        }, 300);


        //--None Part B
        $('.Order' + i + '-Needed-None').unbind('change');
        $('.Order' + i + '-Needed-None').bind('change', function (e) {
            if ($(this).is(':checked')) {
                $('#Order' + i + '-Needed-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
                $('#Order' + i + '-Needed-Disabled select').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Needed-Disabled input:radio').each(function () {
                    $(this).prop('disabled', true);
                    $(this).prop('checked', false);
                });
            } else {
                $('#Order' + i + '-Needed-Disabled input:checkbox').each(function () {
                    $(this).prop('disabled', false);
                });
                $('#Order' + i + '-Needed-Disabled select').each(function () {
                    $(this).prop('disabled', false);
                    $(this).removeClass('input-disabled');
                });
                $('#Order' + i + '-Needed-Disabled input').each(function () {
                    $(this).prop('disabled', false);
                    $(this).removeClass('input-disabled');
                });
            }
        });


        setTimeout(function () {
            if ($('.Order' + i + '-Needed-None').is(':checked')) {
                $('#Order' + i + '-Needed-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });

                $('#Order' + i + '-Needed-Disabled select').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Needed-Disabled input:radio').each(function () {
                    $(this).prop('disabled', true);
                    $(this).prop('checked', false);
                });
            }
        }, 300);

        //--Member refused/Unable to assess
        $('#Order' + i + '-Field01-Highlight label').unbind('click');
        $('#Order' + i + '-Field01-Highlight label').bind('click', function (e) {
            if (this.previous) {
                this.checked = false;
            }
            this.previous = this.checked;

            if ($('#Order' + i + '-Field01-Highlight input:radio:checked').val() == 3) {
                $('#Order' + i + '-Option-Disabled input').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled select').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled div .inputdiv').each(function () {
                    $(this).attr('contenteditable', false);
                    $(this).html('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled-Checkbox input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
                $('#Order' + i + '-Option-Disabled input:radio').each(function () {
                    $(this).prop('disabled', true);
                    $(this).prop('checked', false);
                });
                $('#Order' + i + '-Option-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
            } else {
                $('#Order' + i + '-Option-Disabled input').each(function () {
                    $(this).prop('disabled', false);
                    $(this).removeClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled select').each(function () {
                    $(this).prop('disabled', false);
                    $(this).removeClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled div .inputdiv').each(function () {
                    $(this).attr('contenteditable', true);
                    $(this).removeClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled-Checkbox input:checkbox').each(function () {
                    $(this).prop('disabled', false);
                });

                if ($('.Order' + i + '-Current-None').is(':checked')) {
                    $('#Order' + i + '-Current-Disabled input:checkbox').each(function () {
                        $(this).prop('checked', false);
                        $(this).prop('disabled', true);
                    });
                }
            }

        });

        setTimeout(function () {
            if ($('#Order' + i + '-Field01-Highlight input:radio:checked').val() == 3) {
                $('#Order' + i + '-Option-Disabled input').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled select').each(function () {
                    $(this).prop('disabled', true);
                    $(this).val('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled div .inputdiv').each(function () {
                    $(this).attr('contenteditable', false);
                    $(this).html('');
                    $(this).addClass('input-disabled');
                });
                $('#Order' + i + '-Option-Disabled input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
                $('#Order' + i + '-Option-Disabled-Checkbox input:checkbox').each(function () {
                    $(this).prop('checked', false);
                    $(this).prop('disabled', true);
                });
                $('#Order' + i + '-Option-Disabled  input:radio').each(function () {
                    $(this).prop('disabled', true);
                    $(this).prop('checked', false);
                });
            }

        }, 300);
    }
    function bindingDisableDMEAndOption() {
        for (var i = 44; i < 53; i++) {
            genBindingDisableDMEAndOptionNone(i);
        }
    }
    function bindingHideWHenCheckNone() {
        $('.checknone').unbind('change');
        $('.checknone').bind('change', function (e) {
            if ($(this).is(':checked')) {
                $(".hidewhenchecknone").hide()
            } else {
                $(".hidewhenchecknone").show()
            }

        });
    }
    function bindingTextAreaChange() {
        //$("#content-section textarea").unbind('change');
        //$("#content-section textarea").bind('change', function () {
        //    var val = $("#content-section textarea").val();
        //    $("#content-section textarea").empty().append(val)
        //});
        $('table#content-section textarea').not('tr .list textarea').each(function () {
            if ($(this).val() != "" && $(this).val() != null) {
                this.style.height = "1px";
                this.style.height = (this.scrollHeight) + "px";
            } else {
                this.style.height = "25px";
            }
            //$(this).css({ 'height': this.scrollHeight + 'px' });
            //this.setAttribute('style', 'height:' + (this.scrollHeight) + 'px;border: none;overflow-y:hidden;width:100%; resize:none;border-bottom: 1px dotted #000;padding: 5px 0;margin:0;');
        }).on('input', function () {
            if ($(this).val() != "" && $(this).val() != null) {
                this.style.height = "1px";
                this.style.height = (this.scrollHeight) + "px";
            } else {
                this.style.height = "25px";
            }
        });
    }

    function bindingSelect() {
        $("#content-section").find('select').each(function () {
            $(this).unbind('change');
            $(this).bind('change', function () {
                if ($(this).val() != 'Select Options') {
                    var val = $(this).val();
                    //$(this).find('option').removeAttr('selected');
                    $(this).find('option').each(function () {
                        if ($(this).val() == val) {
                            $(this).attr('selected', 'selected');
                        } else {
                            $(this).removeAttr('selected');
                        }
                    });
                }
            });
        });
    }
    function bindEventLookup() {
        $('table#content-section input.combobox').each(function () {
            var id = $(this).attr('id');
            var ids = id.split('-');
            if (ids.length == 2) {
                bindEventCombobox(null, $(this));
            }
        })
    }

    //handleNonGenerate List2
    function handleNonGenerate() {
        $('table#content-section tr.list2').each(function () {
            bindingEventInList2($(this))
        })
    }

    function bindingEventInList2(el) {

        el.find('input:checkbox').each(function () {
            $(this).unbind('change');
            $(this).bind('change', function () {
                if ($(this).is(':checked')) {
                    $(this).attr('checked', 'checked');
                }
                saveList2($(this));
            });
        })
    }

    function saveList2(field) {
        $scope.saveToList = true;
        var idAttr = field.attr('id');
        if (field.is('input:radio')) {
            idAttr = field.attr('name');
        }
        var ids = idAttr.split('-');
        if (ids.length == 4) {
            var orderInList = getOrderFieldInList(idAttr, 2);
            var orderField = getOrderInId(ids[0]);
            var fieldName = ids[1];
            var fieldNameInList = ids[3];
            for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                    var dataFromJson = [];
                    var dataToJson = null;
                    var isProcess = false;
                    var val = getValInField(field);
                    if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                        dataFromJson = angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]);
                        for (var j = 0; j < dataFromJson.length; j++) {
                            if (dataFromJson[j].Order == parseInt(orderInList)) {
                                if (val != null) {
                                    dataFromJson[j][fieldNameInList] = val;
                                    dataToJson = angular.toJson(dataFromJson);
                                } else {
                                    var isNotEmpty = false;
                                    dataFromJson[j][fieldNameInList] = val;
                                    angular.forEach(dataFromJson[j], function (value, key) {
                                        if (value != null && key !== 'Order') {
                                            isNotEmpty = true;
                                        }
                                    });
                                    if (!isNotEmpty) {
                                        dataFromJson.splice(j, 1);
                                    }
                                    dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                }
                                isProcess = true;
                            }
                        }
                    }
                    if (!isProcess && val != null) {
                        var data = { Order: orderInList };
                        data[fieldNameInList] = val;
                        dataFromJson.push(data);
                        dataToJson = angular.toJson(dataFromJson);
                    }
                    if (dataToJson != null) {
                        vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                    }
                }

            }
        }
    }

    function bindingDataAllList2() {
        $('table#content-section tr.list2').each(function () {
            var el = $(this);
            var curId = el.find('input').attr('id');
            var curIds = curId.split('-');
            var order = parseInt(curIds[0].replace('Order0', '').replace('Order', ''));
            var fieldName = curIds[1];
            for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                if (vm.AssessmentSectionQuestions[i].Order == order && vm.AssessmentSectionQuestions[i][fieldName] != null) {
                    var fromJson = angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]);
                    var total = fromJson.length;
                    if (total > 0) {
                        el.find('input').each(function () {
                            var childEl = $(this)
                            var childId = childEl.attr('id');
                            var childIds = childId.split('-');
                            if (childIds.length == 4) {
                                var childFieldName = childIds[3];
                                var childOrder = parseInt(childIds[2]);
                                for (var j = 0; j < total; j++) {
                                    if (fromJson[j].Order == childOrder && fromJson[j][childFieldName] && fromJson[j][childFieldName] == true) {
                                        if (childEl.is(':checkbox')) {
                                            childEl.attr('checked', 'checked');
                                        }
                                    }
                                }
                            }
                        })
                    }
                }
            }
        });
    }

    //End handleNonGenerate List2
    function handleGenerate() {
        $('table#content-section tr.list').each(function () {
            bindingEventInList($(this));
        })
    }

    //Bind data.
    function appendDataLineInAllList() {
        //clear table before append
        var tblLst = $('table#content-section tr.list');
        tblLst.each(function (index) {
            if (index < tblLst.length - 1) {//kiem tra neu khong phai la dong cuoi cung thi xoa het
                $(this).remove();
            }
        });
        tblLst.each(function () {
            var cloneHtml = $(this).clone()
            var parent = $(this).parent().parent();
            var curId = $(this).find('input').attr('id');
            var curIds = curId.split('-');
            var order = parseInt(curIds[0].replace('Order0', '').replace('Order', ''));
            var fieldName = curIds[1];
            for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                if (vm.AssessmentSectionQuestions[i].Order == order && vm.AssessmentSectionQuestions[i][fieldName] != null) {
                    var fromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                    var total = fromJson.length;
                    if (total > 0) {
                        for (var j = 0; j < total + 1; j++) {
                            $(this).remove();
                            var copyEl = $('<tr class="list"></tr>').html(cloneHtml.html());
                            copyEl.find('textarea').each(function () {
                                var index = 1;
                                if (j < total) {
                                    index = parseInt(fromJson[j].Order) - 1;
                                } else if (j == total && total > 0) {
                                    index = parseInt(fromJson[j - 1].Order);
                                }
                                var curId = '';
                                curId = $(this).attr('id');
                                $(this).attr('id', setNextIndexIdInList(curId, 2, index));

                                var fieldInList = curId.split('-')[3];
                                if (j < total) {
                                    if (fromJson[j][fieldInList]) {
                                        $(this).html(fromJson[j][fieldInList]);

                                    }
                                }
                            });
                            copyEl.find('div.inputdiv').each(function () {
                                var index = 1;
                                if (j < total) {
                                    index = parseInt(fromJson[j].Order) - 1;
                                } else if (j == total && total > 0) {
                                    index = parseInt(fromJson[j - 1].Order);
                                }
                                var curId = '';
                                curId = $(this).attr('id');
                                $(this).attr('id', setNextIndexIdInList(curId, 2, index));

                                var fieldInList = curId.split('-')[3];
                                if (j < total) {
                                    if (fromJson[j][fieldInList]) {
                                        $(this).html(fromJson[j][fieldInList]);

                                    }
                                }
                            });
                            copyEl.find('input, select').each(function () {
                                var index = 1;
                                if (j < total) {
                                    index = parseInt(fromJson[j].Order) - 1;
                                } else if (j == total && total > 0) {
                                    index = parseInt(fromJson[j - 1].Order);
                                }
                                var curId = '';
                                if ($(this).is('input:radio')) {
                                    curId = $(this).attr('name');
                                } else {
                                    curId = $(this).attr('id');
                                }
                                if ($(this).is('input:radio')) {
                                    $(this).attr('name', setNextIndexIdInList(curId, 2, index));
                                } else {
                                    $(this).attr('id', setNextIndexIdInList(curId, 2, index));
                                }
                                var fieldInList = curId.split('-')[3];
                                if (j < total) {
                                    if ($(this).is('input:radio')) {
                                        if (fromJson[j][fieldInList] != null && fromJson[j][fieldInList] === $(this).attr('value')) {
                                            $(this).prop("checked", true);
                                            $(this).attr("checked", 'checked');
                                        }
                                    } else if ($(this).is('input:checkbox')) {
                                        if (fromJson[j][fieldInList] != null && fromJson[j][fieldInList] === true) {
                                            $(this).prop("checked", true);
                                            $(this).attr("checked", 'checked');
                                        }
                                    }
                                    else if ($(this).is('select')) {
                                        if (fromJson[j][fieldInList]) {
                                            $(this).find('option').each(function () {
                                                if ($(this).val() == fromJson[j][fieldInList]) {
                                                    $(this).attr('selected', 'selected');
                                                } else {
                                                    $(this).removeAttr('selected');
                                                }
                                            });
                                        }
                                    }
                                    else {
                                        if (fromJson[j][fieldInList]) {
                                            $(this).val(fromJson[j][fieldInList]);
                                            $(this).attr('value', fromJson[j][fieldInList]);
                                        }
                                    }
                                }
                            });
                            if (cloneHtml.data('indexappend') != undefined) {
                                parent.append('<tr class="list" data-indexappend="' + cloneHtml.data('indexappend') + '">' + copyEl.html() + '</tr>');
                            } else {
                                parent.append('<tr class="list">' + copyEl.html() + '</tr>');
                            }
                            $('table#content-section tr.list').each(function () {
                                bindingEventInList($(this));
                            });
                            bindEventNumberInList();
                        }

                    }

                }
            }
        });
    }

    //End Bind data.

    //After binding.
    function bindingEventInList(el) {
        el.find('input:text').not('.combobox').each(function () {
            $(this).unbind('blur');
            $(this).bind('blur', function () {
                appendAndRemoveLineInList(el, $(this));
                if ($(this).val() != '') {
                    $(this).attr('value', $(this).val());
                }
                saveList($(this));
            });
            //if ($(this).hasClass('combobox')) {
            //    bindEventCombobox(el, $(this));
            //}

            //Item 55
            $('table#content-section .Order55-Field77 tr.list input:text').unbind('blur');
            $('table#content-section .Order55-Field77 tr.list input:text').bind('blur', function (e) {
                appendAndRemoveLineInListInputText($(this), $(this))
                if ($(this).val() != '') {
                    $(this).attr('value', $(this).val());
                }
            });
        })
        el.find('input:checkbox').each(function () {
            $(this).unbind('change');
            $(this).bind('change', function () {
                appendAndRemoveLineInListCheckBox(el, $(this));
                if ($(this).is(':checked')) {
                    $(this).attr('checked', 'checked');
                }
            });
        })
        el.find('input:radio').each(function () {
            $('table#content-section tr.list input:radio').unbind('click');
            $('table#content-section  tr.list input:radio').bind('click', function (e) {
                var value = "";
                if ($(this).is(':checked')) {
                    value = $(this).attr("value");
                    if ($(this).attr("value") === value) {
                        if ($(this).attr("checked") == 'checked') {
                            $(this).removeAttr('checked');
                            $(this).prop('checked', false);
                        } else {
                            $(this).attr('checked', 'checked');
                            $(this).prop('checked', true);
                        }
                    } else {
                        $('table#content-section  tr.list input[name=' + $(this).attr('name') + ']').removeAttr('checked');
                        value = $(this).attr("value");
                        $(this).attr('checked', 'checked');
                        $(this).prop('checked', true);
                    }
                }

                var id = $(this).attr('name');
                appendAndRemoveLineInListRadio($('table#content-section  tr.list input[name=' + $(this).attr('name') + ']'), $(this));
            });

        })
        el.find('select').each(function () {
            $(this).unbind('change');
            $(this).bind('change', function () {
                appendAndRemoveLineInList(el, $(this));
                if ($(this).val() != 'Select Options') {
                    var val = $(this).val()
                    $(this).find('option').each(function () {
                        if ($(this).text() == val) {
                            $(this).attr('selected', 'selected');
                        }
                    });
                }
                saveList($(this));
            });

            //Item 55
            $('table#content-section .Order55-Field77 tr.list select').unbind('change');
            $('table#content-section .Order55-Field77 tr.list select').bind('change', function (e) {
                appendAndRemoveLineInListSelectOption($('table#content-section  tr.list select [id=' + $(this).attr('id') + ']'), $(this))
                if ($(this).val() != '') {
                    var val = $(this).val()
                    $(this).find('option').each(function () {
                        if ($(this).val() == val) {
                            $(this).attr('selected', 'selected');
                        }
                    });
                }
            });
        })
        el.find('div.inputdiv').each(function () {
            $(this).unbind('blur');
            $(this).bind('blur', function () {
                appendAndRemoveLineInListInputDiv($('table#content-section  tr.list div .inputdiv [id=' + $(this).attr('id') + ']'), $(this));

            });
        })

        el.find('.combobox').each(function () {
            localEl = el;
            $(this).unbind('focus');
            $(this).bind('focus', eventOpenComboboxList);
        });
        bindingDivContentLength();

        el.find('textarea').each(function () {
            if ($(this).val() != "" && $(this).val() != null) {
                this.style.height = "1px";
                this.style.height = (this.scrollHeight) + "px";
            } else {
                this.style.height = "25px";
            }
        }).on('input', function () {
            if ($(this).val() != "" && $(this).val() != null) {
                this.style.height = "1px";
                this.style.height = (this.scrollHeight) + "px";
            } else {
                this.style.height = "25px";
            }
            setTimeout(appendAndRemoveLineInListTextArea($(this), $(this)), 300);

        });
    }
    //
    //Start textarea
    function appendLineInListInputTextArea(el) {
        var lastId = el.closest('tr').closest('table').find('tr.list').last().find('input').attr('id');
        var thisId = el.closest('tr').find('input').attr('id');
        if (lastId != undefined && thisId != undefined) {//check case when bind data when choose dropdown
            if (lastId === thisId) {
                var copyEl = $('<tr class="list"></tr>').html(el.closest('tr').html());
                copyEl.find('div.inputdiv').each(function () {
                    var i = getIndexIdInList(lastId, 2);
                    var curId = '';
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                    $(this).html("");
                });
                copyEl.find('input').each(function () {
                    var i = getIndexIdInList(lastId, 2);
                    var curId = '';
                    $(this).removeAttr('value');
                    $(this).val('');
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                })
                copyEl.find('select').each(function () {
                    var i = getIndexIdInList(lastId, 2);
                    var curId = '';
                    $(this).removeAttr('value');
                    $(this).val('');
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                })
                copyEl.find('textarea').each(function () {
                    var i = getIndexIdInList(lastId, 2);
                    var curId = '';
                    $(this).removeAttr('value');
                    $(this).val('');
                    $(this).html('');
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                })
                el.closest('tr').closest('table').append('<tr class="list">' + copyEl.html() + '</tr>');
                $('table#content-section tr.list').each(function () {
                    bindingEventInList($(this));
                });
                bindEventNumber();
            }
        }
    }
    function appendAndRemoveLineInListTextArea(id, thisId) {
        var trParent = thisId.closest('tr');
        if (existedDataTextArea(thisId)) {
            appendLineInListInputTextArea(thisId);
            saveListRadio(thisId, false);
        } else {
            saveListRadio(thisId, true);
            if (trParent.is(":last-child")) {
            } else {
                trParent.remove();
            }
        }
    }
    function existedDataTextArea(el) {
        var result = false;
        var trParent = el.closest('tr');
        trParent.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                }
            }
        });
        trParent.find('select').each(function () {
            if (!result) {
                result = $(this).val() != '';
                if ($(this).val() != '')
                    return true;
            }
        });
        trParent.find('.inputdiv').each(function () {
            if (!result && $(this).html() != '' && $(this).html() != '<br>') {
                result = true;
            }
        });
        trParent.find('textarea').each(function () {
            if (!result && $(this).val().trim() != '') {
                result = true;
            }
        });
        return result;
    }
    //End textarea

    //Start combobox       
    function saveListCombobox(field, isDeleted) {
        $scope.saveToList = true;
        var idAttr = field.attr('id');
        if (field.is('input:radio')) {
            idAttr = field.attr('name');
        }
        var ids = idAttr.split('-');
        if (ids.length == 4) {
            var orderInList = getOrderFieldInList(idAttr, 2);
            var orderField = getOrderInId(ids[0]);
            var fieldName = ids[1];
            var fieldNameInList = ids[3];
            if (isDeleted) {
                for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                    if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                        var dataFromJson = [];
                        var dataToJson = null;

                        if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                            dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                            for (var j = 0; j < dataFromJson.length; j++) {
                                if (dataFromJson[j].Order == parseInt(orderInList)) {
                                    dataFromJson.splice(j, 1);
                                    dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                    vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                                }
                            }
                        }

                    }
                }
            } else {
                for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                    if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                        var dataFromJson = [];
                        var dataToJson = null;
                        var isProcess = false;
                        var val = getValInField(field);
                        if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                            dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                            for (var j = 0; j < dataFromJson.length; j++) {
                                if (dataFromJson[j].Order == parseInt(orderInList)) {
                                    if (val != null) {
                                        dataFromJson[j][fieldNameInList] = val;
                                        dataToJson = angular.toJson(dataFromJson);
                                    } else {
                                        var isNotEmpty = false;
                                        dataFromJson[j][fieldNameInList] = val;
                                        angular.forEach(dataFromJson[j], function (value, key) {
                                            if (value != null && key !== 'Order') {
                                                isNotEmpty = true;
                                            }
                                        });
                                        if (!isNotEmpty) {
                                            dataFromJson.splice(j, 1);
                                        }
                                        dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                    }
                                    isProcess = true;
                                }
                            }
                        }
                        if (!isProcess && val != null) {
                            var data = { Order: orderInList };
                            data[fieldNameInList] = val;
                            dataFromJson.push(data);
                            dataToJson = angular.toJson(dataFromJson);
                        }
                        if (dataToJson != null) {
                            vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                        }
                    }
                }
            }
        }
    }
    function existedDataCombobox(el) {
        var result = false;
        var trParent = el.closest('tr');
        trParent.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                }
            }
        });

        trParent.find('.inputdiv').each(function () {
            if (!result && $(this).html() != '' && $(this).html() != '<br>') {
                result = true;
            }
        });
        trParent.find('textarea').each(function () {
            if (!result && $(this).val().trim() != '') {
                result = true;
            }
        });
        return result;
    }
    function appendAndRemoveLineInListCombox(id, thisId) {
        var trParent = id.closest('tr');
        if (existedDataCombobox(id)) {
            appendLineInListInputText(id);
            saveListCombobox(thisId, false);
        } else {
            saveListCombobox(thisId, true);
            if (trParent.is(":last-child")) {
            } else {
                trParent.remove();
            }
        }
    }
    function closeComboboxList(cmb, parent, cmbClone) {
        cmb.data("kendoComboBox").destroy();
        parent.empty();
        parent.append(cmbClone.focus(eventOpenComboboxList));
        parent.append(cmbClone.keydown(eventOpenComboboxList));
        if (cmb.attr('id').split('-').length != 2) {
            appendAndRemoveLineInListCombox(parent.parent(), parent.children());
        }
    }
    function eventOpenComboboxList() {
        var cmb = $(this), parent = cmb.parent(), cmbClone = cmb.clone();
        var lst = cmb.data('lst'),
            data = [],
            required = cmb.data('required'),
            url = cmb.data('urltool'),
            params = cmb.data('params'),
            query = cmb.data('query') == true,
            bindfield = cmb.data('bindfield'),
            splitfield = cmb.data('splitfield');
        var dataSource = null;
        if (lst != undefined) {
            data = lst.split(";");
            dataSource = data;
        } else {
            var urlRes = url;
            //if (params != undefined) {
            //    var paramsList = params.split(',');              
            //        for (var i = 0; i < paramsList.length; i++) {
            //            urlRes = urlRes.replace('{' + i + '}', vm[paramsList[i]]);
            //        }                               
            //}
            if (query) {
                dataSource = new kendo.data.DataSource({
                    serverFiltering: true,
                    transport: {
                        read: {
                            url: urlRes,
                        },
                        parameterMap: function (options, type) {
                            var value = '';
                            if (options.filter !== undefined && options.filter.filters != undefined && options.filter.filters[0] != undefined && options.filter.filters[0].value !== '') {
                                value = options.filter.filters[0].value;
                            }
                            value = "query=" + value;
                            return value;
                        }
                    }
                });
            } else {
                dataSource = new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: urlRes,
                        }
                    }
                });
            }
        }

        function replaceLastField(id, replaceField) {
            var spl = id.split('-');
            if (spl.length == 4) {
                spl[3] = replaceField
            }
            return spl.join('-');
        }

        cmb.kendoComboBox({
            dataSource: dataSource,
            filter: "contains",
            suggest: true,
            dataBound: function (e) {
                parent.find('.k-combobox').css({ 'padding': '0', "height": "25px" });
                parent.find('.k-combobox span.k-select').css({ "line-height": "25px" });
                //, 'width': parent.find('.k-combobox').width() - parent.find('.k-combobox span.k-select').width()
                $("[data-role=combobox]").each(function () {
                    var widget = $(this).getKendoComboBox();
                    widget.input.on("focus", function () {
                        widget.open();
                    });
                });
            },
            select: function (e) {
                if (query) {
                    if (bindfield != undefined && splitfield != undefined) {
                        var fields = bindfield.split(',');
                        var vals = e.item.text().split(splitfield);
                        for (var j = 0; j < fields.length; j++) {
                            if (j == 0) {
                                cmbClone.val(vals[0]);
                                cmbClone.attr('value', vals[0]);
                            } else {
                                var idAttr = replaceLastField(cmbClone.attr('id'), fields[j])
                                $('#' + idAttr).val(vals[j]);
                                $('#' + idAttr).attr('value', vals[j]);
                                $('#' + idAttr).html(vals[j]);
                                saveList($('#' + idAttr));
                                $('textarea').trigger("input");
                            }
                        }

                    } else {
                        cmbClone.val(e.item.text());
                        cmbClone.attr('value', e.item.text());
                    }
                } else {
                    cmbClone.val(e.item.text());
                    cmbClone.attr('value', e.item.text());
                }
                //closeComboboxList(cmb, parent, cmbClone);
            },

            change: function (e) {
                var value = this.value();
                if (value == '') {
                    cmbClone.val("");
                    cmbClone.attr('value', "");
                }
                closeComboboxList(cmb, parent, cmbClone);
            }
        });


        cmb.data("kendoComboBox").open();
        var tempInput = parent.find('.k-combobox').find('span').find('input');
        tempInput.focus();
        parent.find('.k-combobox').find('span').on('blur', 'input', function (e) {
            if (!required) {
                cmbClone.val(tempInput.val());
            }
            closeComboboxList(cmb, parent, cmbClone);
        });
    }
    //End combobox
    //Start inputdiv
    function appendAndRemoveLineInListInputDiv(id, thisId) {
        var trParent = thisId.closest('tr');
        if (existedDataInputDiv(thisId)) {
            appendLineInListInputText(thisId);
            saveListRadio(thisId, false);
        } else {
            saveListRadio(thisId, true);
            if (trParent.is(":last-child")) {
            } else {
                trParent.remove();
            }
        }
    }
    function existedDataInputDiv(el) {
        var result = false;
        var trParent = el.closest('tr');
        trParent.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                }
            }
        });
        trParent.find('select').each(function () {
            if (!result) {
                result = $(this).val() != '';
                if ($(this).val() != '')
                    return true;
            }
        });
        trParent.find('.inputdiv').each(function () {
            if (!result && $(this).html() != '' && $(this).html() != '<br>') {
                result = true;
            }
        });
        trParent.find('textarea').each(function () {
            if (!result && $(this).val().trim() != '') {
                result = true;
            }
        });
        return result;
    }
    //End inputdiv

    //Start Input Text
    function appendAndRemoveLineInListInputText(id, thisId) {
        var trParent = thisId.closest('tr');
        if (existedDataInputText(thisId)) {
            appendLineInListInputText(thisId);
            saveListRadio(thisId, false);
        } else {
            saveListRadio(thisId, true);
            if (trParent.is(":last-child")) {
            } else {
                trParent.remove();
            }
        }
    }
    function appendLineInListInputText(el) {
        var lastId = el.closest('tr').closest('table').find('tr.list').last().find('input').attr('id');
        var thisId = el.closest('tr').find('input').attr('id');
        if (lastId === thisId) {
            var copyEl = $('<tr class="list"></tr>').html(el.closest('tr').html());
            copyEl.find('div.inputdiv').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                $(this).html("");
            });
            copyEl.find('input').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                $(this).removeAttr('value');
                $(this).val('');
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            copyEl.find('select').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                $(this).removeAttr('value');
                $(this).val('');
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            copyEl.find('textarea').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                $(this).removeAttr('value');
                $(this).val('');
                $(this).html('');
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            el.closest('tr').closest('table').append('<tr class="list">' + copyEl.html() + '</tr>');
            $('table#content-section tr.list').each(function () {
                bindingEventInList($(this));
            });
            bindEventNumber();
        }
    }
    function existedDataInputText(el) {
        var result = false;
        var trParent = el.closest('tr');
        trParent.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                }
            }
        });
        trParent.find('select').each(function () {
            if (!result) {
                result = $(this).val() != '';
                if ($(this).val() != '')
                    return true;
            }
        });
        trParent.find('textarea').each(function () {
            if (!result && $(this).val().trim() != '') {
                result = true;
            }
        });
        return result;
    }
    //End Input Text

    //Start Select Option
    function appendAndRemoveLineInListSelectOption(id, thisId) {
        var trParent = thisId.closest('table').closest('tr');
        if (existedDataSelectOption(thisId)) {
            appendLineInListSelectOption(thisId);
            saveListRadio(thisId, false);
        } else {
            saveListRadio(thisId, true);
            if (trParent.is(":last-child")) {
            } else {
                trParent.remove();
            }
        }
    }
    function existedDataSelectOption(el) {
        var result = false;
        var trParent = el.closest('table').closest('tr');
        trParent.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                }
            }
        });
        trParent.find('select').each(function () {
            if (!result) {
                result = $(this).val() != '';
                if ($(this).val() != '')
                    return true;
            }
        });
        return result;
    }
    function appendLineInListSelectOption(el) {
        var lastId = el.closest('table').closest('tr').closest('table').find('tr.list').last().find('input').attr('id');
        var thisId = el.closest('table').closest('tr').find('input').attr('id');
        if (lastId === thisId) {
            var copyEl = $('<tr class="list"></tr>').html(el.closest('table').closest('tr').html());
            copyEl.find('input').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                $(this).removeAttr('value');
                $(this).val('');
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            copyEl.find('select').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                $(this).removeAttr('value');
                $(this).val('');
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            el.closest('table').closest('tr').closest('table').append('<tr class="list">' + copyEl.html() + '</tr>');
            $('table#content-section tr.list').each(function () {
                bindingEventInList($(this));
            });
            bindEventNumber();
        }
    }
    //End Select Option
    //Start Checkbox
    function appendAndRemoveLineInListCheckBox(el, field) {
        if (existedData(el)) {
            if (checkIndexAppend(el, field)) {
                appendLineInList(el);
                saveListRadio(field, false);
            }
        } else {
            removeLineInList(el);
            saveListRadio(field, true);
        }
    };
    //End Checkbox

    //Start Radio Button
    function saveListRadio(field, isDeleted) {
        $scope.saveToList = true;
        var idAttr = field.attr('id');
        if (field.is('input:radio')) {
            idAttr = field.attr('name');
        }
        var ids = idAttr.split('-');
        if (ids.length == 4) {
            var orderInList = getOrderFieldInList(idAttr, 2);
            var orderField = getOrderInId(ids[0]);
            var fieldName = ids[1];
            var fieldNameInList = ids[3];
            if (isDeleted) {
                for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                    if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                        var dataFromJson = [];
                        var dataToJson = null;

                        if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                            dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                            for (var j = 0; j < dataFromJson.length; j++) {
                                if (dataFromJson[j].Order == parseInt(orderInList)) {
                                    dataFromJson.splice(j, 1);
                                    dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                    vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                                }
                            }
                        }

                    }
                }
            } else {
                for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                    if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                        var dataFromJson = [];
                        var dataToJson = null;
                        var isProcess = false;
                        var val = getValInField(field);
                        if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                            dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                            for (var j = 0; j < dataFromJson.length; j++) {
                                if (dataFromJson[j].Order == parseInt(orderInList)) {
                                    if (val != null) {
                                        dataFromJson[j][fieldNameInList] = val;
                                        dataToJson = angular.toJson(dataFromJson);
                                    } else {
                                        var isNotEmpty = false;
                                        dataFromJson[j][fieldNameInList] = val;
                                        angular.forEach(dataFromJson[j], function (value, key) {
                                            if (value != null && key !== 'Order') {
                                                isNotEmpty = true;
                                            }
                                        });
                                        if (!isNotEmpty) {
                                            dataFromJson.splice(j, 1);
                                        }
                                        dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                    }
                                    isProcess = true;
                                }
                            }
                        }
                        if (!isProcess && val != null) {
                            var data = { Order: orderInList };
                            data[fieldNameInList] = val;
                            dataFromJson.push(data);
                            dataToJson = angular.toJson(dataFromJson);
                        }
                        if (dataToJson != null) {
                            vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                        }
                    }
                }
            }
        }
    }
    function appendAndRemoveLineInListRadio(id, thisId) {
        if (existedDataRadio(id)) {
            appendLineInListRadio(id);
            saveListRadio(thisId, false);
        } else {
            saveListRadio(thisId, true);
            if (id.closest("tr").is(":last-child")) {
            } else {
                id.closest("tr").remove();
            }

        }
    }
    function appendLineInListRadio(el) {
        var lastId = el.parent().parent().parent().parent().parent().find('tr.list').last().find('input').attr('id');
        var thisId = el.parent().parent().parent().parent().find('input').attr('id');
        if (lastId === thisId) {
            var copyEl = $('<tr class="list"></tr>').html(el.parent().parent().parent().parent().html());
            copyEl.find('input').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                if ($(this).is('input:radio') || $(this).is('input:checkbox')) {
                    $(this).removeAttr('checked');
                    if ($(this).is('input:radio')) {
                        $(this).removeAttr('id');
                        curId = $(this).attr('name');
                        $(this).attr('name', setNextIndexIdInList(curId, 2, i));
                    } else {
                        curId = $(this).attr('id');
                        $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                    }
                } else {
                    $(this).removeAttr('value');
                    $(this).val('');
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                }
            })
            el.parent().parent().parent().parent().parent().parent().append('<tr class="list">' + copyEl.html() + '</tr>');
            $('table#content-section tr.list').each(function () {
                bindingEventInList($(this));
            });
            bindEventNumber();
        }
    }
    function existedDataRadio(el) {
        var result = false;
        el.closest('tr').find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                    if ($(this).val() != '')
                        return true;
                } else if ($(this).is('input:checkbox') || $(this).is(':radio')) {
                    result = $(this).is(':checked');
                    if ($(this).is(':checked'))
                        return true;
                }
            }
        });
        return result;
    }
    //End Radio Button
    function appendAndRemoveLineInList(el, field) {
        if (existedData(el)) {
            if (checkIndexAppend(el, field)) {
                appendLineInList(el);
            }
        } else {
            removeLineInList(el);
        }
    }

    function checkIndexAppend(el, field) {
        var indexAppendStr = el.data('indexappend');
        var idAttr = field.attr('id');
        if (field.is('input:radio')) {
            idAttr = field.attr('name');
        }
        var indexAppend = getOrderFieldInList(idAttr, 3);
        if (indexAppendStr != undefined) {
            if (indexAppendStr.indexOf(indexAppend) > -1) {
                return true;
            }
        } else {
            return true;
        }
        return false;
    }

    function existedData(el) {
        var result = false;
        el.find('input').each(function () {
            if (!result) {
                if ($(this).is('input:text')) {
                    result = $(this).val() != '';
                } else if ($(this).is('input:checkbox') || $(this).is(':radio')) {
                    result = $(this).is(':checked');
                }
            }
        });
        el.find('select').each(function () {
            if (!result && $(this).val() != 'Select Options') {
                result = true;
            }
        });
        el.find('.inputdiv').each(function () {
            if (!result && $(this).html() != '' && $(this).html() != '<br>') {
                result = true;
            }
        })
        return result;
    }

    function appendLineInList(el) {
        var isAppend = false;
        var lastId = el.parent().find('tr.list').last().find('input').attr('id');
        var thisId = el.find('input').attr('id');
        if (lastId === thisId) {
            var copyEl = $('<tr class="list"></tr>').html(el.html());
            copyEl.find('div.inputdiv').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                curId = $(this).attr('id');
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                $(this).html("");
            });
            copyEl.find('input, select').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                if ($(this).is('input:radio')) {
                    curId = $(this).attr('name');
                } else {
                    curId = $(this).attr('id');
                }
                $(this).attr('id', setNextIndexIdInList(curId, 2, i));
            })
            copyEl.find('input').each(function () {
                var i = getIndexIdInList(lastId, 2);
                var curId = '';
                if ($(this).is('input:radio') || $(this).is('input:checkbox')) {
                    $(this).removeAttr('checked');
                    if ($(this).is('input:radio')) {
                        $(this).removeAttr('id');
                        curId = $(this).attr('name');
                        $(this).attr('name', setNextIndexIdInList(curId, 2, i));
                    } else {
                        curId = $(this).attr('id');
                        $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                    }
                } else {
                    $(this).removeAttr('value');
                    $(this).val('');
                    curId = $(this).attr('id');
                    $(this).attr('id', setNextIndexIdInList(curId, 2, i));
                }
            })
            if (el.data('indexappend') != undefined) {
                el.parent().parent().append('<tr class="list" data-indexappend="' + el.data('indexappend') + '">' + copyEl.html().replace('display: none;', '') + '</tr>');
            } else {
                el.parent().parent().append('<tr class="list">' + copyEl.html() + '</tr>');
            }

            $('table#content-section tr.list').each(function () {
                bindingEventInList($(this));
            });
            bindEventNumber();
        }
        else {
            $('table#content-section tr.list').each(function () {
                bindingEventInList($(this));
            });
        }

    }

    function getIndexIdInList(idAttr, i) {
        var slit = idAttr.split('-');
        if (slit.length > i) {
            return parseInt(slit[i]);
        }
    }

    function getOrderFieldInList(idAttr, i) {
        var slit = idAttr.split('-');
        if (slit.length > i) {
            return slit[i].replace('Field0', '').replace('Field', '');
        }
    }

    function setNextIndexIdInList(idAttr, i, val) {

        var slit = idAttr.split('-');
        if (slit.length > i) {
            slit[i] = (val + 1) + '';
        }
        return slit.join('-');
    }

    function removeLineInList(el) {
        if (el.parent().find('tr.list').length > 1) {
            $scope.saveToList = true;
            var lastId = el.parent().find('tr.list:last-child input').attr('id')
            var thisId = el.find('input').attr('id');
            if (lastId !== thisId) {
                var ids = thisId.split('-');
                if (ids.length == 4) {
                    var orderField = getOrderInId(ids[0]);
                    var fieldName = ids[1];
                    var orderInList = ids[2];
                    for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                        if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                            var dataFromJson = [];
                            var dataToJson = null;
                            var isProcess = false;
                            if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                                dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                                for (var j = 0; j < dataFromJson.length; j++) {
                                    if (dataFromJson[j].Order == parseInt(orderInList)) {
                                        dataFromJson.splice(j, 1);
                                        break;
                                    }
                                }
                                dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                            }

                        }
                    }

                }
                el.remove();
            }
        }
    }

    function bindEventNumberInList() {
        $('table#content-section tr.list input.number').unbind('keypress');
        $('table#content-section tr.list input.number').bind('keypress', function (e) {
            var key = e.charCode || e.keyCode;
            if (key > 47 && key < 58) {
                var number = $(this);
                if (number.val().length === 1 && number.val() == '0') {
                    number.val('');
                }
            } else {
                if (key != 8 && key != 46) {
                    e.preventDefault();
                }
            }
        });
    }

    //End After binding.
    //Save value 
    function saveList(field) {
        $scope.saveToList = true;
        var idAttr = field.attr('id');
        if (field.is('input:radio')) {
            idAttr = field.attr('name');
        }
        var ids = idAttr.split('-');
        if (ids.length == 4) {
            var orderInList = getOrderFieldInList(idAttr, 2);
            var orderField = getOrderInId(ids[0]);
            var fieldName = ids[1];
            var fieldNameInList = ids[3];
            for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
                if (vm.AssessmentSectionQuestions[i].Order === orderField) {
                    var dataFromJson = [];
                    var dataToJson = null;
                    var isProcess = false;
                    var val = getValInField(field);
                    if (vm.AssessmentSectionQuestions[i][fieldName] != null && vm.AssessmentSectionQuestions[i][fieldName] != '') {
                        dataFromJson = common.decodeObject(angular.fromJson(vm.AssessmentSectionQuestions[i][fieldName]));
                        for (var j = 0; j < dataFromJson.length; j++) {
                            if (dataFromJson[j].Order == parseInt(orderInList)) {
                                if (val != null) {
                                    dataFromJson[j][fieldNameInList] = val;
                                    dataToJson = angular.toJson(dataFromJson);
                                } else {
                                    var isNotEmpty = false;
                                    dataFromJson[j][fieldNameInList] = val;
                                    angular.forEach(dataFromJson[j], function (value, key) {
                                        if (value != null && key !== 'Order') {
                                            isNotEmpty = true;
                                        }
                                    });
                                    if (!isNotEmpty) {
                                        dataFromJson.splice(j, 1);
                                    }
                                    dataToJson = dataFromJson.length > 0 ? angular.toJson(dataFromJson) : null;
                                }
                                isProcess = true;
                            }
                        }
                    }
                    if (!isProcess && val != null) {
                        var data = { Order: orderInList };
                        data[fieldNameInList] = val;
                        dataFromJson.push(data);
                        dataToJson = angular.toJson(dataFromJson);
                    }
                    if (dataToJson != null) {
                        vm.AssessmentSectionQuestions[i][fieldName] = dataToJson;
                    }
                }

            }
        }
    }

    function getValInField(field) {
        if (field.is('textarea')) {
            return field.val() == '' ? null : field.val();
        }
        else if (field.is('div.inputdiv')) {
            return field.html() == '<br>' ? null : field.html();
        }
        else if (field.is('input:checkbox')) {
            return field.is(':checked');
        }
        else if (field.is('input:radio')) {
            if (field.is(':checked')) {
                return field.attr("value");
            }
            return null;
        }
        else {
            return field.val() == '' ? null : field.val();
        }
    }

    function getOrderInId(val) {
        var result = 0;
        result = parseInt(val.replace('Order0', '').replace('Order', ''));
        return result;
    }

    //End Save value
    /// End Nghiep -----------------------------------------

    /// Tung ----------------------------------------------
    function eventOpenCombobox() {
        var cmb = $(this), parent = cmb.parent(), cmbClone = cmb.clone();
        var lst = cmb.data('lst'),
            data = [],
            required = cmb.data('required'),
            url = cmb.data('urltool'),
            params = cmb.data('params'),
            query = cmb.data('query') == true,
            bindfield = cmb.data('bindfield'),
            splitfield = cmb.data('splitfield');
        var dataSource = null;
        if (lst != undefined) {
            data = lst.split(";");
            dataSource = data;
        } else {
            var urlRes = url;
            //if (params != undefined) {
            //    var paramsList = params.split(',');              
            //        for (var i = 0; i < paramsList.length; i++) {
            //            urlRes = urlRes.replace('{' + i + '}', vm[paramsList[i]]);
            //        }                               
            //}
            if (query) {
                dataSource = new kendo.data.DataSource({
                    serverFiltering: true,
                    transport: {
                        read: {
                            url: urlRes,
                        },
                        parameterMap: function (options, type) {
                            var value = '';
                            if (options.filter !== undefined && options.filter.filters != undefined && options.filter.filters[0] != undefined && options.filter.filters[0].value !== '') {
                                value = options.filter.filters[0].value;
                            }
                            value = "query=" + value;
                            return value;
                        }
                    }
                });
            } else {
                dataSource = new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: urlRes,
                        }
                    }
                });
            }
        }

        function replaceLastField(id, replaceField) {
            var spl = id.split('-');
            if (spl.length == 4) {
                spl[3] = replaceField
            }
            return spl.join('-');
        }

        cmb.kendoComboBox({
            dataSource: dataSource,
            filter: "contains",
            suggest: true,
            dataBound: function (e) {
                parent.find('.k-combobox').css({ 'padding': '0', "height": "25px" });
                parent.find('.k-combobox span.k-select').css({ "line-height": "25px" });
                //, 'width': parent.find('.k-combobox').width() - parent.find('.k-combobox span.k-select').width()
            },
            select: function (e) {
                if (query) {
                    if (bindfield != undefined && splitfield != undefined) {
                        var fields = bindfield.split(',');
                        var vals = e.item.text().split(splitfield);
                        for (var j = 0; j < fields.length; j++) {
                            if (j == 0) {
                                cmbClone.val(vals[0]);
                                cmbClone.attr('value', vals[0]);
                            } else {
                                var idAttr = replaceLastField(cmbClone.attr('id'), fields[j])
                                $('#' + idAttr).val(vals[j]);
                                $('#' + idAttr).attr('value', vals[j]);
                                $('#' + idAttr).html(vals[j]);
                                saveList($('#' + idAttr));
                            }
                        }

                    } else {
                        cmbClone.val(e.item.text());
                        cmbClone.attr('value', e.item.text());
                    }
                } else {
                    cmbClone.val(e.item.text());
                    cmbClone.attr('value', e.item.text());
                }

                //closeCombobox(cmb, parent, cmbClone);
            },
            change: function (e) {
                var value = this.value();
                if (value == '') {
                    cmbClone.val("");
                    cmbClone.attr('value', "");
                }
                closeCombobox(cmb, parent, cmbClone);
            }
        });

        cmb.data("kendoComboBox").open();
        var tempInput = parent.find('.k-combobox').find('span').find('input');
        tempInput.focus();
        parent.find('.k-combobox').find('span').on('blur', 'input', function (e) {
            if (!required) {
                cmbClone.val(tempInput.val());
            }
            closeCombobox(cmb, parent, cmbClone);
        });
    }

    var localEl = null;

    function closeCombobox(cmb, parent, cmbClone) {
        cmb.data("kendoComboBox").destroy();
        parent.empty();
        parent.append(cmbClone.focus(eventOpenCombobox));
        parent.append(cmbClone.keydown(eventOpenCombobox));
        if (cmb.attr('id').split('-').length != 2) {
            appendAndRemoveLineInList(localEl, cmb);
        }
        saveList(cmbClone);
    }

    function bindEventCombobox(el, cmb) {
        localEl = el;
        cmb.not("tr.list .combobox").unbind('focus');
        cmb.not("tr.list .combobox").bind('focus', eventOpenCombobox);
        //cmb.unbind('mouseup');
        //cmb.bind('mouseup', eventOpenCombobox);
    }

    /// End Tung ------------------------------------------

    //Thao ----------------------------------------------------- 

    function installGridPhysician() {
        vm.returnSelect = function (item) {
            $('table#content-section input#Order28-Field01').attr('value', item.FullName);
            $('table#content-section input#Order28-Field01').val(item.FullName);

            $('table#content-section input#Order29-Field01').attr('value', item.Npi);
            $('table#content-section input#Order29-Field01').val(item.Npi);

            $('table#content-section input#Order30-Field01').attr('value', item.Mpi);
            $('table#content-section input#Order30-Field01').val(item.Mpi);

            $('table#content-section input#Order31-Field01').attr('value', item.PhoneInFormat);
            $('table#content-section input#Order31-Field01').val(item.PhoneInFormat);

            $('table#content-section input#Order32-Field01').attr('value', item.FaxInFormat);
            $('table#content-section input#Order32-Field01').val(item.FaxInFormat);

            $('table#content-section input#Order33-Field01').attr('value', item.ClinicName);
            $('table#content-section input#Order33-Field01').val(item.ClinicName);

            $('table#content-section input#Order33-Field02').attr('value', item.Address1);
            $('table#content-section input#Order33-Field02').val(item.Address1);

            $('table#content-section input#Order33-Field03').attr('value', item.Address2);
            $('table#content-section input#Order33-Field03').val(item.Address2);

            $('table#content-section input#Order33-Field04').attr('value', item.Zip);
            $('table#content-section input#Order33-Field04').val(item.Zip);

            $('table#content-section input#Order33-Field05').attr('value', item.City);
            $('table#content-section input#Order33-Field05').val(item.City);

            $('table#content-section input#Order33-Field06').attr('value', item.State);
            $('table#content-section input#Order33-Field06').val(item.State);


            vm.popupInstallSelectPhysician.close();
        };

        vm.clearText = function () {
            vm.FirstName = "";
            vm.LastName = "";
            vm.NPI = "";
            vm.IsGetTotalForGrid = true;
            vm.dataSource.read();
        }

        vm.search = function (e) {
            if (e == undefined || e.keyCode === 13) {
                //var jsonSearchText = {};
                //jsonSearchText.NPI = ((vm.NPI == "" || vm.NPI == undefined) ? "" : vm.NPI);
                //jsonSearchText.PhysicianFullName = ((vm.PhysicianFullName == "" || vm.PhysicianFullName == undefined) ? "" : vm.PhysicianFullName);
                //var advancedSearch = JSON.stringify(jsonSearchText);
                //vm.SearchTextEncoded = advancedSearch;
                vm.dataSource._skip = 0;
                vm.IsGetTotalForGrid = true;
                vm.dataSource.read();
            }
        }

        var schemaFields = {
            Id: { editable: false },
            Name: { editable: false }
        };


        vm.dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: "http://localhost:9000/api/Npi",
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8'
                },
                parameterMap: function (options, operation) {
                    if (operation === "read") {
                        var result = {
                            pageSize: options.pageSize,
                            skip: options.skip,
                            take: options.take,
                            FirstName: vm.FirstName,
                            LastName: vm.LastName,
                            NPI: vm.NPI,
                        };
                        return "queryInfo=" + Base64.encode(angular.toJson(result));
                    }
                }
            },

            serverPaging: true,
            serverSorting: true,
            pageSize: 10,
            batch: true,
            emptyMsg: 'No Record',
            table: "#physicianAdvancedSearchGrid",
            schema: {
                model: {
                    id: "Id",
                    fields: schemaFields
                },
                data: "Data",

                total: "TotalRowCount"
            },

        });
        vm.gridOptions = {

            dataSource: vm.dataSource,
            pageable: {
                refresh: true,
            },
            height: 300,
            dataBound: function () {
                $('[data-toggle="tooltip"]').tooltip({
                    container: 'body',
                });
            },
            autoBind: false,
            columns: [
                {
                    field: "Npi",
                    title: "NPI",
                    width: "80px"
                },
                {
                    field: "FirstName",
                    title: "First Name",
                    width: "80px"
                },
                {
                    field: "LastName",
                    title: "Last Name",
                    width: "80px"
                },
                {
                    field: "PhoneInFormat",
                    title: "Phone",
                    width: "80px"
                }, {
                    field: "FullAddress",
                    title: "Address",
                    width: "150px"
                }
                , {
                    field: "",
                    title: "",
                    width: "50px",
                    template: "<button ng-click='vm.returnSelect(dataItem)' class='btn btn-default btn-alt' data-toggle='tooltip' data-placement='bottom' title='Select'><i class='fa fa-hand-o-left'></i></button>"
                }
            ]
        };
    }
    function closeDatepicker(id, value) {
        var valueField = value;
        if (value == null || value == undefined) {
            valueField = "";
        } else {
            valueField = kendo.toString(value, 'd');
            var comp = valueField.split('/');
            var m = comp[0];
            var d = comp[1];
            var y = comp[2];
            var date = new Date(y, m - 1, d);
            if (date.getFullYear() != y || date.getMonth() + 1 != m || date.getDate() != d) {
                valueField = "";
            } else {
                valueField = m + "/" + d + "/" + y;
            }
        }

        if ($("#" + id).data("kendoDatePicker") != undefined) {
            var kendoDatePicker = $("#" + id).data("kendoDatePicker");
            kendoDatePicker.destroy();
            $("#AssessmentCompleteDate").empty();
            $("#AssessmentCompleteDate").append('<input  value="' + valueField + '" id="' + id + '"  placeholder="MM/dd/yyyy"  type="text" style="width: 100%; border: none;padding: 5px 0 0 0;border-bottom: 1px dotted #000;" />');
            //$("div.k-animation-container").remove();
            bindDatepicker(id);
        }
    }
    function openDatepicker(id) {
        var data = $("#" + id).val();
        //closeDatepicker();
        $("#" + id).kendoDatePicker({
            format: "MM/dd/yyyy",
            change: function () {
                closeDatepicker(id, $("#" + id).val());
            },
            close: function () {
                var value = this.value();
                closeDatepicker(id, $("#" + id).val());
            }
        });
        var kendoDatePicker = $("#" + id).data("kendoDatePicker");
        kendoDatePicker.value(data);
        kendoDatePicker.open();
        $("#" + id).kendoMaskedTextBox({
            mask: "00/00/0000"
        });
        $("#" + id).unbind('click');
    }
    function bindDatepicker(field) {
        $("#" + field).click(function () {
            openDatepicker(field);
        });
    }
    //End -----Thao ----------------------------------------------------------

    function bindEventSelectPhysician() {
        $('#popupAdvanceSearchPhysicianPcst').unbind('click');
        $('#popupAdvanceSearchPhysicianPcst').bind('click', function (e) {
            vm.popupInstallSelectPhysician.open();
            $('#physicianAdvancedSearchGrid').data('kendoGrid').dataSource.read();
            $('#physicianAdvancedSearchGrid').data('kendoGrid').refresh();
        });
    }

    function bindEventPhone() {
        $('table#content-section input.phone').mask("(999) 999-9999");
    }

    function bindEventHour() {
        $('table#content-section input.hour').mask("99:99", { placeholder: "HH:mm" });
    }
    function bindEventDate() {
        $('table#content-section input.date').mask("99/99/9999", { placeholder: "MM/dd/yyyy" });
    }
    function bindEventNumber() {
        $('table#content-section input.number').unbind('keypress');
        $('table#content-section input.number').bind('keypress', function (e) {
            var key = e.charCode || e.keyCode;
            if (key > 47 && key < 58) {
                var number = $(this);
                if (number.val().length === 1 && number.val() == '0') {
                    number.val('');
                }
            } else {
                if (key != 8 && key != 46) {
                    e.preventDefault();
                }
            }
        });
    }

    function bindEventSignature() {
        $('table#content-section input.signature').unbind('focus');

        $('table#content-section input.signature').bind('focus', function (e) {
            common.checkAndSetWidthPopup(vm.popupInstallSignature);
            vm.popupInstallSignature.open();
            //if (getSign() != undefined && getSign() != "") {
            //    vm.mySign.fromDataURL(getSign());
            //}
            signatureId = $(this).attr('id');
        });
        $('table#content-section input.signature').unbind('keypress');
        $('table#content-section input.signature').bind('keypress', function (e) {
            e.preventDefault();
        });
    }

    function getContentHtmlByOrder(order) {
        for (var i = 0; i < vm.Sections.length; i++) {
            if (vm.Sections[i].Order === order) {
                var content = vm.Sections[i].Content;
                content = content.replace('id="Section' + order + '-Header"', "style='display:none;'");
                for (var j = 0; j < vm.Sections[i].SectionQuestions.length; j++) {
                    content = content.replace("{{Order" + vm.Sections[i].SectionQuestions[j].Order + "}}", vm.Sections[i].SectionQuestions[j].Content);
                }
                return $sce.trustAsHtml(content);
            }
        }
    }

    function callBindForNextSection() {
        var name = '';
        $timeout(function () {
            $('table#content-section input').each(function (index) {
                if ($(this).is(':radio')) {
                    if (name != $(this).attr('name')) {
                        name = $(this).attr('name');
                        bindValueFromList(name, true);
                    }
                } else {
                    bindValueFromList($(this).attr('id'));
                }
            });

            $('table#content-section select').each(function (index) {
                bindValueFromList($(this).attr('id'), false, true);

            });
            appendDataLineInAllList();
            bindingDataAllList2();
            $("#content-container .xy_content form").scrollTop(0);
            //bind data to textarea 
            $('table#content-section textarea').each(function (index) {
                bindValueFromList($(this).attr('id'));
            });
            $('table#content-section div.inputdiv').each(function (index) {
                bindValueFromList($(this).attr('id'));
            });

        });
    }

    function bindValueFromList(id, isRadio, isSelect) {
        var ids = id.split('-');
        if (ids.length == 2) {
            var orderNo = parseInt(ids[0].replace('Order', ''));
            var fieldNo = ids[1].replace('Field', '');
            var field = fieldNo.length === 1 ? "Field0" + fieldNo : ids[1];
            var obj = getSectionQuestion(orderNo);
            if (isSelect) {
                if (obj[field] != null && obj[field] != '') {
                    $('table#content-section select#' + id + ' option').each(function () {
                        if ($(this).val() === obj[field]) {
                            $(this).attr('selected', 'selected');
                        }
                    });
                }
            } else {

                if (obj) {
                    if (isRadio) {
                        if (obj[field]) {
                            $('table#content-section input[name=' + id + '][value=' + obj[field] + ']').attr('checked', 'checked');
                            $('table#content-section input[name=' + id + '][value=' + obj[field] + ']').prop('checked', true);
                        }

                    } else {
                        var $input = $('table#content-section input#' + id);
                        if (obj[field]) {
                            if ($input.attr('type') === 'checkbox') {
                                if (obj[field].toLowerCase() == 'true') {
                                    $input.attr('checked', 'checked');
                                    $input.prop('checked', true);

                                    if ($('.checknone').is(':checked')) {
                                        $(".hidewhenchecknone").hide()
                                    } else {
                                        $(".hidewhenchecknone").show()
                                    }

                                } else {
                                    $(".hidewhenchecknone").show()
                                }
                            } else {
                                if ($input.attr('class') === 'signature') {
                                    var img = '<img id="' + id + '-signature" alt="Signature" style="margin-left:20px;width:50%;" src="' + obj[field] + '" />';
                                    vm.Signature = obj[field];
                                    $('#' + id).parent().prepend(img);
                                } else {
                                    $input.attr('value', obj[field]);
                                    $input.val(obj[field]);
                                }
                            }
                            //bind data to textarea
                            $('table#content-section textarea#' + id).val(obj[field]);

                            //bind data to div.inputdiv
                            $('table#content-section div.inputdiv#' + id).html(obj[field]);


                        } else {//value is null => clear all value
                            if ($input.attr('type') === 'checkbox') {
                                $input.attr('checked', false);
                            } else {
                                $input.val('')
                            }

                        }
                    }
                    bindingTextAreaChange();
                }
            }
        }
    }

    function getSectionQuestion(orderNo) {
        for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
            if (vm.AssessmentSectionQuestions[i].Order === orderNo) {
                return vm.AssessmentSectionQuestions[i];
            }
        }
        return null;
    }

    function callSaveNextSection(oval, IsRemoveHighlight) {
        if (IsRemoveHighlight) {
            removeHighlight();
        }
        var name = '';
        $('table#content-section input').not("tr .list input").each(function (index) {
            if ($(this).is(':radio')) {
                if (name != $(this).attr('name')) {
                    name = $(this).attr('name');
                    var val = $('input[name=' + $(this).attr('name') + ']:checked').val();
                    saveToObject($(this).attr('name'), val);
                }
            } else {

                if ($(this).is(':checkbox')) {
                    var valCheckbox = $(this).prop('checked');
                    saveToObject($(this).attr('id'), valCheckbox == true ? 'true' : null);
                } else {
                    if ($(this).attr('class') === 'signature') {
                        saveToObject($(this).attr('id'), vm.Signature);
                    } else {
                        saveToObject($(this).attr('id'), $(this).val());
                    }
                }
            }
        });
        $('table#content-section select').not("tr.list select").each(function (index) {
            saveToObject($(this).attr('id'), $(this).val());
        });
        //get value from textarea set to field in database
        $('table#content-section textarea').not("tr.list textarea").each(function (index) {
            saveToObject($(this).attr('id'), $(this).val());
        });
        //Save value if div.inputdiv
        $('table#content-section div.inputdiv').not("tr.list div.inputdiv").each(function (index) {
            saveToObject($(this).attr('id'), $(this).html() == '<br>' ? null : $(this).html());
        });
    }

    function hasInputItemInListType1(id) {
        var obj = { Field01: '', Field02: '', Field03: '' };
        var flagHasInput = false;
        for (var i = 1; i <= 3; i++) {
            var idOrder = id + '-Field0' + i;
            if ($('#' + idOrder).val() !== '') {
                obj["Field0" + i] = $('#' + idOrder).val();
                flagHasInput = true;
            }
        }
        if (flagHasInput) {
            return obj;
        }
        return null;
    }

    function getValueDivInput(id) {
        var text = "";
        id.find("div").each(function () {
            if ($(this).children("input:first").val() != undefined) {
                text = text + $(this).children("input:first").val();
            } else {
                text = text + "/ ";
            };
        });
        return text;
    }

    vm.removeLastRowBeforeGetContent = function () {
        if ($('#tbAppendRowTable tbody tr.list:last') != undefined && $('#tbAppendRowTable tbody tr.list:last').length >= 1) {
            if ($('#tbAppendRowTable tbody tr.list:last').is(':first-child')) {

            } else {
                $('#tbAppendRowTable tbody tr.list:last').remove();
            }
        }
    }
    function saveToObject(id, val) {
        var ids = id.split('-');
        if (ids.length == 2) {
            var orderNo = parseInt(ids[0].replace('Order', ''));
            var fieldNo = ids[1].replace('Field', '');
            var field = fieldNo.length === 1 ? "Field0" + fieldNo : ids[1];
            if (val && val != '') {
                if ($('table#content-section input#' + id).attr('type') === 'checkbox') {
                    if ($('table#content-section input#' + id).prop('checked')) {
                        setSectionQuestion(orderNo, field, 'true');
                    }
                } else {
                    setSectionQuestion(orderNo, field, val);
                }
            }
            else {
                setSectionQuestion(orderNo, field, null);
            }
        }

    }

    function setSectionQuestion(orderNo, field, val) {
        for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
            if (vm.AssessmentSectionQuestions[i].Order === orderNo) {
                vm.AssessmentSectionQuestions[i][field] = val;
            }
        }
    }

    vm.save = function (IsShowMessage) {
        //start Disclose Form
        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
        if (vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed) {
            convertToOtherAsListed();
            if (vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.length > 1) {
                vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.pop();
            }
        }
        vm.DisclosureForm.Member.DobStr = vm.doBTemp;
        vm.DisclosureForm.Member.Signature = vm.memberSignature.isEmpty() ? "_blank" : vm.memberSignature.toDataURL();
        vm.DisclosureForm.Guardian.Signature = vm.guardianSignature.isEmpty() ? "_blank" : vm.guardianSignature.toDataURL();

        vm.DisclosureForm.Providers = [];
        if (vm.AgencyId != null && vm.AgencyName != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.AgencyId, Name: vm.AgencyName, Order: 1 });
        }
        if (vm.Agency2Id != null && vm.Agency2Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency2Id, Name: vm.Agency2Name, Order: 2 });
        }
        if (vm.Agency3Id != null && vm.Agency3Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency3Id, Name: vm.Agency3Name, Order: 3 });
        }
        //end Disclose Form

        callSaveNextSection(vm.SectionItemSelected);
        var data = {
            Id: vm.RequestId,
            RequestNo: vm.RequestNo,
            AssessmentPcsId: vm.AssessmentPcsId,
            AssessmentName: vm.AssessmentName,
            Sections: vm.Sections,
            AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
            IsSaveAll: true,
            DisclosureFormVo: vm.DisclosureForm
        }
        var encodeData = JSON.stringify(Base64.encode(angular.toJson(data)));
        $(".loader").fadeIn();
        $http.post('http://localhost:9000/api/Assessment/Save', encodeData).then(function (result) {
            vm.AssessmentPcsId = result.data.Id;
            if (IsShowMessage) {
                if (result.data.Error != null) {
                    $(".loader").fadeOut();
                    //vm.ShowErrorInValid(result.data.Error);
                    if (result.data.Error.length > 0) {
                        toaster.pop('success', "", "Save successfully.", null, 'trustedHtml');
                        //vm.popupInstallSaveData.open();
                    }
                } else {
                    $(".loader").fadeOut();
                    //winformObj.cancel();
                    toaster.pop('success', "", "Save successfully.", null, 'trustedHtml');
                }
            } else {
                $(".loader").fadeOut();
            }
        });
    }

    vm.saveWhenNextSection = function () {
        var deferred = $q.defer();
        //start Disclose Form
        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
        if (vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed) {
            convertToOtherAsListed();
            if (vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.length > 1) {
                vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.pop();
            }
        }
        vm.DisclosureForm.Member.DobStr = vm.doBTemp;
        vm.DisclosureForm.Member.Signature = vm.memberSignature.isEmpty() ? "_blank" : vm.memberSignature.toDataURL();
        vm.DisclosureForm.Guardian.Signature = vm.guardianSignature.isEmpty() ? "_blank" : vm.guardianSignature.toDataURL();

        vm.DisclosureForm.Providers = [];
        if (vm.AgencyId != null && vm.AgencyName != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.AgencyId, Name: vm.AgencyName, Order: 1 });
        }
        if (vm.Agency2Id != null && vm.Agency2Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency2Id, Name: vm.Agency2Name, Order: 2 });
        }
        if (vm.Agency3Id != null && vm.Agency3Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency3Id, Name: vm.Agency3Name, Order: 3 });
        }

        var data = {
            Id: vm.RequestId,
            RequestNo: vm.RequestNo,
            AssessmentPcsId: vm.AssessmentPcsId,
            AssessmentName: vm.AssessmentName,
            Sections: vm.Sections,
            AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
            IsSaveAll: false,
            DisclosureFormVo: vm.DisclosureForm
        }

        var encodeData = JSON.stringify(Base64.encode(angular.toJson(data)));
        $http.post('http://localhost:9000/api/Assessment/Save', encodeData).then(function (result) {
            deferred.resolve(result);
            vm.AssessmentPcsId = result.data.Id;
        });
        return deferred.promise;
    }
    vm.back = function () {
        $state.go("RequestTaskDetail", { id: vm.TaskActionParamViewModel.RequestTaskId }, { reload: true });
    }
    vm.mySign = null;
    var signatureId = null;
    function getSign() {
        if (vm.AssessmentSectionQuestions != null && vm.AssessmentSectionQuestions.length > 0) {
            for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {

                if (vm.AssessmentSectionQuestions[i].IsSignature == true) {
                    return vm.AssessmentSectionQuestions[i].Field01;
                }
            }
        } else {
            return null;
        }
    };
    function setSign(val) {
        for (var i = 0; i < vm.AssessmentSectionQuestions.length; i++) {
            if (vm.AssessmentSectionQuestions[i].IsSignature == true) {
                vm.AssessmentSectionQuestions[i].Field01 = val;
            }
        }
    };

    $scope.$on("kendoWidgetCreated", function (event, widget) {
        if (widget === vm.popupInstallSignature) {
            vm.popupInstallSignature.title('Signature');
            vm.popupInstallSignature.center();
            vm.popupInstallSignature.clearsign = function () {
                vm.mySign.clear();
            };
            vm.popupInstallSignature.sign = function () {
                if (!vm.mySign.isEmpty()) {
                    $('#' + signatureId + '-signature').remove();
                    vm.Signature = vm.mySign.toDataURL();
                    var img = '<img id="' + signatureId + '-signature" alt="Signature" style="margin-left:20px;width:50%;" src="' + vm.Signature + '" />';
                    $('#' + signatureId).parent().prepend(img);
                    setSign(vm.Signature);
                    vm.popupInstallSignature.close();
                } else {
                    var error = [];
                    error.push({ MessageError: "Signature is required." });
                    vm.ShowErrorInValid(error);
                }
            };
            vm.popupInstallSignature.bind('close', function () {
                vm.mySign.clear();
            });
            vm.popupInstallSignature.bind('open', function () {
                if (getSign() != undefined && getSign() != "") {
                    vm.mySign.fromDataURL(getSign());
                }
            });


        }

        if (widget === vm.popupInstallSelectPhysician) {
            vm.popupInstallSelectPhysician.title('Choose Physician');
            vm.popupInstallSelectPhysician.center();

            vm.popupInstallSelectPhysician.bind('close', function () {
                vm.clearText();
            });

        }

        if (widget === vm.popupInstallSelectProvider) {
            vm.popupInstallSelectProvider.title('Advance Search Provider');
            vm.popupInstallSelectProvider.center();

            vm.popupInstallSelectProvider.bind('close', function () {
                vm.clearTextProvider();
            });

        }

        if (widget === vm.popupInstallSaveData) {
            vm.popupInstallSaveData.title('Confirm');
            vm.popupInstallSaveData.center();
            vm.popupInstallSaveData.bind('close', function () {

            });
            vm.popupInstallSaveData.save = function () {
            };

        }
    });
    vm.closePopup = function () {
        // winformObj.cancel();
        vm.popupInstallSaveData.close();
    }


    vm.IsShowNextSection = true;
    vm.NextSection = function () {
        if (vm.SectionItemSelected != undefined && vm.SectionItemSelected.Order != undefined) {
            vm.SectionItemSelected = vm.SectionList[vm.SectionItemSelected.Order];
        }
        if (vm.SectionItemSelected != undefined && vm.SectionList != undefined) {
            vm.SetShowNextSection();
        }

    }
    vm.SetShowNextSection = function () {
        if (vm.SectionItemSelected.Order < vm.SectionList.length) {
            vm.IsShowNextSection = true;
        } else {
            vm.IsShowNextSection = false;
        }
    }
    vm.PrevSection = function () {
        if (vm.SectionItemSelected != undefined && vm.SectionItemSelected.Order != undefined) {
            if (vm.SectionItemSelected.Order > 1) {
                vm.SectionItemSelected = vm.SectionList[vm.SectionItemSelected.Order - 2];
            }
        }
        if (vm.SectionItemSelected != undefined && vm.SectionList != undefined) {
            vm.SetShowNextSection();
        }

    }

    vm.ShowErrorInValid = function (listError) {
        var mess = "<ol>";
        var isExistMess = false;
        if (listError.length > 0) {
            //for (var i = 0; i < listError.length; i++) {
            //    mess += "<li>" + listError[i] + "</li>";
            //}
            for (var i = 0; i < listError.length; i++) {
                mess += "<li>" + listError[i].MessageError + "</li>";
                $("#" + listError[i].Id + "-Highlight").addClass("border-highlight");
                $scope.listErrorIdOld.push(listError[i].Id + "-Highlight");
            }
        } else {
            return;
        }
        mess += "</ol>";
        toaster.pop('error', "Following business rules failed:", mess, null, 'trustedHtml');
        setHeighError();
    }

    vm.ShowSuccessMessage = function () {
        toaster.pop('success', "", $scope.tabSelected == 1 ? "Disclosure Form is valid." : "This section is valid.", null, 'trustedHtml');
        setHeighError();
    }
    vm.ShowSuccessMessageVerifyAll = function () {
        toaster.pop('success', "", "PCST Form is valid.", null, 'trustedHtml');
        setHeighError();
    }

    $scope.listErrorIdOld = [];
    var removeHighlight = function () {
        if ($scope.listErrorIdOld.length > 0) {
            for (var i = 0; i < $scope.listErrorIdOld.length; i++) {
                $("#" + $scope.listErrorIdOld[i]).removeClass("border-highlight");
            }
        }
    }

    vm.Verify = function () {
        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
        if (vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed) {
            convertToOtherAsListed();
            if (vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.length > 1) {
                vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.pop();
            }
        }
        vm.DisclosureForm.Member.DobStr = vm.doBTemp;
        vm.DisclosureForm.Member.Signature = vm.memberSignature.isEmpty() ? "_blank" : vm.memberSignature.toDataURL();
        vm.DisclosureForm.Guardian.Signature = vm.guardianSignature.isEmpty() ? "_blank" : vm.guardianSignature.toDataURL();

        vm.DisclosureForm.Providers = [];
        if (vm.AgencyId != null && vm.AgencyName != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.AgencyId, Name: vm.AgencyName, Order: 1 });
        }
        if (vm.Agency2Id != null && vm.Agency2Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency2Id, Name: vm.Agency2Name, Order: 2 });
        }
        if (vm.Agency3Id != null && vm.Agency3Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency3Id, Name: vm.Agency3Name, Order: 3 });
        }
        callSaveNextSectionVerify(vm.SectionItemSelected);
        var data = {
            Id: vm.RequestId,
            RequestNo: vm.RequestNo,
            AssessmentPcsId: vm.AssessmentPcsId,
            AssessmentName: vm.AssessmentName,
            Sections: vm.Sections,
            AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
            IsSaveAll: false,
            DisclosureFormVo: vm.DisclosureForm,
            CurrentSectionId: vm.SectionItemSelected.Order,
            TabSelected: $scope.tabSelected
        }

        var encodeData = JSON.stringify(Base64.encode(angular.toJson(data)));
        $http.post('http://localhost:9000/api/Assessment/Verify', encodeData).then(function (result) {
            vm.AssessmentPcsId = result.data.Id;
            if (result.data.Error != null) {
                vm.ShowErrorInValid(result.data.Error);
            } else {
                vm.ShowSuccessMessage();
            }
        });
    };

    vm.VerifyAll = function () {
        vm.DisclosureForm.OtherAsListed.OtherDisclosureForms = [];
        if (vm.DisclosureForm.OtherAsListed.IsHasOtherAsListed) {
            convertToOtherAsListed();
            if (vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.length > 1) {
                vm.DisclosureForm.OtherAsListed.OtherDisclosureForms.pop();
            }
        }
        vm.DisclosureForm.Member.DobStr = vm.doBTemp;
        vm.DisclosureForm.Member.Signature = vm.memberSignature.isEmpty() ? "_blank" : vm.memberSignature.toDataURL();
        vm.DisclosureForm.Guardian.Signature = vm.guardianSignature.isEmpty() ? "_blank" : vm.guardianSignature.toDataURL();

        vm.DisclosureForm.Providers = [];
        if (vm.AgencyId != null && vm.AgencyName != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.AgencyId, Name: vm.AgencyName, Order: 1 });
        }
        if (vm.Agency2Id != null && vm.Agency2Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency2Id, Name: vm.Agency2Name, Order: 2 });
        }
        if (vm.Agency3Id != null && vm.Agency3Name != "") {
            vm.DisclosureForm.Providers.push({ Id: vm.Agency3Id, Name: vm.Agency3Name, Order: 3 });
        }

        callSaveNextSectionVerify(vm.SectionItemSelected);
        var data = {
            Id: vm.RequestId,
            RequestNo: vm.RequestNo,
            AssessmentPcsId: vm.AssessmentPcsId,
            AssessmentName: vm.AssessmentName,
            Sections: vm.Sections,
            AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
            DisclosureFormVo: vm.DisclosureForm,
            TabSelected: $scope.tabSelected
        }
        var encodeData = JSON.stringify(Base64.encode(angular.toJson(data)));
        $http.post('http://localhost:9000/api/Assessment/Verify', encodeData).then(function (result) {
            vm.AssessmentPcsId = result.data.Id;
            if (result.data.Error != null) {
                vm.ShowErrorInValid(result.data.Error);
            } else {
                vm.ShowSuccessMessageVerifyAll();
            }
        });
    };

    vm.validationGridOptions = {
        dataSource: null,
        sortable: false,
        height: 430,
        columns: [
            {
                field: "Index",
                title: "#",
                width: "35px"
            }, {
                field: "MessageError",
                title: "Message",
                width: "350px",
            }
        ]
    };
    vm.Submit = function () {
        callSaveNextSectionVerify(vm.SectionItemSelected);

        var data = {
            Id: vm.RequestId,
            RequestNo: vm.RequestNo,
            AssessmentPcsId: vm.AssessmentPcsId,
            Sections: vm.Sections,
            AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
            TaskActionParamViewModel: vm.TaskActionParamViewModel,
            IsSubmit: true
        }
        var encodeData = Base64.encode(angular.toJson(data));
        $http.post('/Initial/Assessment/Verify', { parameters: encodeData }).then(function (result) {
            $scope.listErrorIdOld = [];
            if (result.data.IsValid == false) {
                if (result.data.MessageErrorTotal.length > 0) {
                    //var dataSource = new kendo.data.DataSource({
                    //    data: result.data.MessageErrorTotal
                    //});
                    //vm.gridValidation.setDataSource(dataSource);
                    //vm.gridValidation.refresh();

                    //for (var i = 0; i < result.data.MessageErrorTotal.length; i++) {
                    //    $("#" + result.data.MessageErrorTotal[i].Id + "-Highlight").addClass("border-highlight");
                    //    $scope.listErrorIdOld.push(result.data.MessageErrorTotal[i].Id + "-Highlight");
                    //}

                    //$('#grid-validation .k-grid-content-expander').css('width', '');
                    //common.checkAndSetWidthPopup(vm.popupValidateForm);
                    //vm.popupValidateForm.center();
                    //vm.popupValidateForm.open();

                    var mess = common.getMessageFromSystemMessage('BussinessGenericErrorMessageKey', []);
                    mess += "<ol>";
                    for (var i = 0; i < result.data.MessageErrorTotal.length; i++) {
                        mess += "<li>" + result.data.MessageErrorTotal[i].MessageError + "</li>";
                        $("#" + result.data.MessageErrorTotal[i].Id + "-Highlight").addClass("border-highlight");
                        $scope.listErrorIdOld.push(result.data.MessageErrorTotal[i].Id + "-Highlight");
                    }
                    mess += "</ol>";
                    logError(mess);
                    setHeighError();
                }
            } else {
                common.bootboxConfirm(common.getMessageFromSystemMessage('CompleteAssessmentComfirm', []), function () {
                    callSaveNextSection(vm.SectionItemSelected);
                    var data1 = {
                        Id: vm.RequestId,
                        RequestNo: vm.RequestNo,
                        AssessmentPcsId: vm.AssessmentPcsId,
                        Sections: vm.Sections,
                        AssessmentSectionQuestions: vm.AssessmentSectionQuestions,
                        TaskActionParamViewModel: vm.TaskActionParamViewModel,
                        IsSubmit: true
                    }
                    var encodeData1 = Base64.encode(angular.toJson(data1));
                    $http.post('/Initial/Assessment/Submit', { parameters: encodeData1 }).then(function (result) {
                        $scope.listErrorIdOld = [];
                        if (result.data.IsValid == false) {
                            var mess = common.getMessageFromSystemMessage('BussinessGenericErrorMessageKey', []);
                            mess += "<ol>";
                            for (var i = 0; i < result.data.MessageErrorTotal.length; i++) {
                                mess += "<li>" + result.data.MessageErrorTotal[i].MessageError + "</li>";
                                $("#" + result.data.MessageErrorTotal[i].Id + "-Highlight").addClass("border-highlight");
                                $scope.listErrorIdOld.push(result.data.MessageErrorTotal[i].Id + "-Highlight");
                            }
                            mess += "</ol>";
                            logError(mess);
                            setHeighError();
                        }
                        else {
                            if ($localStorage.menuList.CanViewViewAllTask) {
                                $injector.get('$state').transitionTo('ViewAllTask', { id: vm.TaskActionParamViewModel.RequestTaskId });
                            } else if ($localStorage.menuList.CanViewTask) {
                                $injector.get('$state').transitionTo('Task', { id: vm.TaskActionParamViewModel.RequestTaskId });
                            }
                            logSuccess(common.getMessageFromSystemMessage('CompleteAssessmentSuccessfully', []));
                        }
                    });
                }, function () { }).modal('show');
            }
        });
    }

    function callSaveNextSectionVerify(oval) {
        removeHighlight();
        var name = '';
        $('table#content-section input').each(function (index) {
            if ($(this).is(':radio')) {
                if (name != $(this).attr('name')) {
                    name = $(this).attr('name');
                    var val = $('input[name=' + $(this).attr('name') + ']:checked').val();
                    saveToObject($(this).attr('name'), val);
                }
            } else {

                if ($(this).is(':checkbox')) {
                    var valCheckbox = $(this).prop('checked');
                    saveToObject($(this).attr('id'), valCheckbox == true ? 'true' : null);
                } else {
                    if ($(this).attr('class') === 'signature') {
                        saveToObject($(this).attr('id'), vm.Signature);
                    } else {
                        saveToObject($(this).attr('id'), $(this).val());
                    }
                }
            }
        });
        $('table#content-section select').each(function (index) {
            saveToObject($(this).attr('id'), $(this).val());
        });

        //get value from textarea set to field in database
        $('table#content-section textarea').each(function (index) {
            saveToObject($(this).attr('id'), $(this).val());
        });

        //Save value if div.inputdiv
        $('table#content-section div.inputdiv').each(function (index) {
            saveToObject($(this).attr('id'), $(this).html() == '<br>' ? null : $(this).html());
        });
    }

    var heightError = $(window).height() - 100;
    function setHeighError() {
        $("#toast-container").css({ "overflow-y": "auto", "max-height": heightError });
    };

    $scope.tabSelected = 1;
    $scope.setTabSelected = function (val) {
        $scope.tabSelected = val;
    }

    vm.CloseAndConfirm = function () {
        vm.popupInstallSaveData.open();
    }
    vm.CloseAndSave = function () {
        vm.isLoadingExecute = true;
        vm.save(false);
        setTimeout(function () {
            vm.isLoadingExecute = false;
            winformObj.cancel();
        }, 2000);
    }
    vm.CloseAndDontSave = function () {
        winformObj.cancel();
    }
    //-------------------------------
    vm.isLoadingExecute = false;


}]);

