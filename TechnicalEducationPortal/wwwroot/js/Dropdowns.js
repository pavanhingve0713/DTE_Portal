function BindDivisions(ths) {
    $("#DistrictId").html('');
    $("#BlockId").html('');
    var divisonsList = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindDivision",
        data: { stateId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        divisonsList += "<option value=" + v.DivisionId + ">" + v.DivisionCode + '-' + v.DivisionNameEng + "</option>";
                    }

                });
            }
            $("#DivisionId").html(divisonsList);
            $("#DistrictId").html("<option value=''>Select</option>");
            $("#BlockId").html("<option value=''>Select</option>");
            $("#VillageId").html("<option value=''>Select</option>");
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindDistrict(ths) {
    $("#BlockId").empty();
    let districtList = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindDistrict",
        data: { divisionId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    districtList += "<option value=" + v.DistrictId + ">" + v.DistrictCode + '-' + v.DistrictNameEng + "</option>";
                });
            }
            $("#DistrictId").html(districtList);
            $("#BlockId").html("<option value=''>Select</option>");
            $("#VillageId").html("<option value=''>Select</option>");
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindBlock(ths) {
    let blocklist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindBlock",
        data: { districtId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    blocklist += "<option value=" + v.BlockId + ">" + v.BlockCode + '-' + v.BlockNameEng + "</option>";
                });
            }
            $("#BlockId").html(blocklist);
            $("#VillageId").html("<option value=''>Select</option>");
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function BindVillageByBlock(ths) {
    let villagelist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindVillageByBlock",
        data: { blockId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        villagelist += "<option value=" + v.VillageId + ">" + v.VillageCode + '-' + v.VillageNameEng + "</option>";
                    }
                });
            }
            $("#VillageId").html(villagelist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindBank() {
    let banklist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindBank",
        /* data: { districtId: ths },*/
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    banklist += "<option value=" + v.BankId + ">" + v.BankName + "</option>";
                });
            }
            $("#BankId").html(banklist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindIFSCCode(ths) {
    let ifsclist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindIFSCCode",
        data: { bankId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {

                    ifsclist += "<option value=" + v.IFCSCodeId + ">" + v.IFSCCode + "</option>";
                });
            }
            $("#IFCSCodeId").html(ifsclist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindMgmtGroupDetails(ths) {
    debugger;
    let MgmgGrouplist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindMgmtGroupDetails",
        data: { SchoolMgmtGroupId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        MgmgGrouplist += "<option value=" + v.SchoolMgmtGroupDetailId + ">" + v.SchoolMgmtCode + '-' + v.SchoolMgmtNameEng + "</option>";
                    }

                });
            }
            $("#SchoolMgmtGroupDetailId").html(MgmgGrouplist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function BindSchoolSubCategoryDetails(ths) {
    debugger;
    let SubCategoryDetailslist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindSchoolSubCategoryDetails",
        data: { SchoolCategoryId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        SubCategoryDetailslist += "<option value=" + v.SchoolSubCatDetailId + ">" + v.SchoolSubCatDetailCode + '-' + v.SchoolSubCatDetail + "</option>";
                    }

                });
            }
            $("#SchoolSubCatDetailId").html(SubCategoryDetailslist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function BindGramPanchayat(ths) {
    debugger;
    let GramPanchayatlist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindGramPanchayat",
        data: { blockId: ths },
        success: function (response) {

            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        GramPanchayatlist += "<option value=" + v.GramPanchayatId + ">" + v.GramPanchayatCode + '-' + v.GramPanchayatEng + "</option>";
                    }

                });
            }
            $("#GramPanchayatId").html(GramPanchayatlist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindJanpadPanchayat(ths) {
    debugger;
    let JanpadPanchayatlist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindJanpadPanchayat",
        data: { blockId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        JanpadPanchayatlist += "<option value=" + v.JanpadPanchayatId + ">" + v.JanpadPanchayatCode + '-' + v.JanpadPanchayatEng + "</option>";
                    }

                });
            }
            $("#JanpadPanchayatId").html(JanpadPanchayatlist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function BindVillage(ths) {
    debugger;
    let Villagelist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindVillage",
        data: { GramPanchayatId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        Villagelist += "<option value=" + v.VillageId + ">" + v.VillageCode + '-' + v.VillageNameEng + "</option>";
                    }

                });
            }
            $("#VillageId").html(Villagelist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindJilaPanchayat(ths) {
    debugger;
    let JilaPanchayatlist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindJilaPanchayat",
        data: { DistrictId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        JilaPanchayatlist += "<option value=" + v.JilaPanchayatId + ">" + v.JilaPanchayaCode + '-' + v.JilaPanchayaNameEng + "</option>";
                    }

                });
            }
            $("#JilaPanchayatId").html(JilaPanchayatlist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindNagarNigam(ths) {
    debugger;
    let NagarNigamlist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindNagarNigam",
        data: { BlockId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        NagarNigamlist += "<option value=" + v.NagarNigamId + ">" + v.NagarNigamCode + '-' + v.NagarNigamNameEng + "</option>";
                    }

                });
            }
            $("#NagarNigamId").html(NagarNigamlist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindNagarPalika(ths) {
    debugger;
    let NagarPalikalist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindNagarPalika",
        data: { BlockId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        NagarPalikalist += "<option value=" + v.NagarPalikaId + ">" + v.NagarPalikaCode + '-' + v.NagarPalikaNameEng + "</option>";
                    }

                });
            }
            $("#NagarPalikaId").html(NagarPalikalist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindHabitation(ths) {
    debugger;
    let Habitationlist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindHabitation",
        data: { VillageId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        Habitationlist += "<option value=" + v.HabitationId + ">" + v.HabitationCode + '-' + v.HabitationNameEng + "</option>";
                    }

                });
            }
            $("#HabitationId").html(Habitationlist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function BindParliamentary(ths) {
    debugger;
    let Parliamentarylist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindParliamentary",
        data: { DistrictId: ths },
        success: function (response) {
            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        Parliamentarylist += "<option value=" + v.ParliamentaryId + ">" + v.ParliamentaryCode + '-' + v.ParliamentaryNameEng + "</option>";
                    }

                });
            }
            $("#ParliamentaryId").html(Parliamentarylist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
function BindAssembly(ths) {
    debugger;
    let Assemblylist = "<option value=''>Select</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/BindAssembly",
        data: { DistrictId: ths },
        success: function (response) {

            if (response != null) {
                $.each(response, function (i, v) {
                    if (v.IsActive == true) {
                        Assemblylist += "<option value=" + v.AssemblyId + ">" + v.AssemblyCode + '-' + v.AssemblyNameEng + "</option>";
                    }

                });
            }

            $("#AssemblyId").html(Assemblylist);
        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

//Added by bhanu on 13-12-2023 Bind Sankul and School list
function BindSchoollist(ths) {
    //debugger;
    let Sankullist = "<option value=''>Select</option>";
    $.ajax({
        type: 'post',
        url: "/DropDowns/GetSchoolandSankulforMapping",
        data: { id: ths },
        success: function (data) {
           // debugger;
            $("#SankulId").children().remove().end().append("<option value='0'>Select</option>");
            if (data != null) {
              //  debugger;
                $.each(data, function (i, v) {
                    Sankullist += "<option value=" + v.sankulId + ">" + v.sankulName + "</option>";
                })
            }
            $("#SankulId").html(Sankullist);
        }
    });
}

function BindDistrictByStateId(ths, type) {
    debugger;
    let districtList = "<option value=''>-- Select --</option>";
    $.ajax({
        type: "POST",
        url: "/DropDowns/GetDistrictByStateId",
        data: { Id: ths },
        success: function (response) {
            if (ths == "") {
                response = null;
            }
            if (response != null) {
                $.each(response, function (i, v) {
                    districtList += "<option value=" + v.DistrictId + ">" + v.DistrictCode + '-' + v.DistrictNameEng + "</option>";
                });
            }
            if (type == "present") {
                $("#PrDistrict").html(districtList);
            }
            else if (type == "permanent") {
                $("#PeDistrict").html(districtList);
            }
            else {
                $("#DistrictId").html(districtList);
            }

        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}

function GetSankulBySchoolId(ths) {
    debugger;
    let sankulList = "<option value=''>Select</option> <option value='001'>Sankul 01</option>" ;
    $.ajax({
        type: "POST",
        url: "/DropDowns/GetSankulBySchoolId",
        data: { Id: ths },
        success: function (response) {
            console.log(response);
            if (response != null) {
                $.each(response, function (i, v) {
                    sankulList += "<option value=" + v.SankulId + ">" + v.SankulId + "</option>";
                });            
            }
            $("#SankulId").html(sankulList);

        },
        failure: function () {
            //alert();
        },
        error: function () {
            //alert();
        }
    });
}
