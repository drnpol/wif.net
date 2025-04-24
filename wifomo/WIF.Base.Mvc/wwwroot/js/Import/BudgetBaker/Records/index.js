
$(document).ready(function () {
    var dataSourceOverviewGrid = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Import/BudgetBaker/GetRecords"
            },
            parameterMap: function (data, operation) {
                if (operation == "read") {
                    var pagingString = '"Paging": {"Skip": ' + data.skip + ', "Take": ' + data.pageSize + ' }';
                    var filterString = '';

                    if (data.filter) {
                        var fltr = [];
                        data.filter.filters.forEach(function (item) {
                            fltr.push({ "Field": item["field"], "Value": item["value"], "Operator": item["operator"] });
                        });
                        filterString = ', "Filter": ' + JSON.stringify(fltr);
                    }
                    var requestString = '{' + pagingString + filterString + '}';

                    //return { mkmversionid: $('#mkmVersionDropdownId').val(), kendoListRequestString: requestString };
                    return { kendoListRequestString: requestString };
                }
                if (operation == "create" && data.models) {
                    return { productName: data.models[0].name, mainCategorieID: data.models[0].mainCategorie };
                }
            }
        },
        serverPaging: true,
        serverFiltering: true,
        sort: { field: "productName", dir: "asc" },
        requestEnd: function (e) {
            var response = e.response;
            var type = e.type;
            if (type !== "read" && type !== undefined) {
                e.sender.read();
            }
        },
        batch: true,
        pageSize: 50,
        schema: {
            total: "totalEntries",
            type: "json",
            data: "entries",
            model: {
                id: "id",
                fields: {
                    id: { field: "id", nullable: false },
                }
            }
        }
    });

    $("#grid").kendoGrid({
        dataSource: dataSourceOverviewGrid,
        height: 550,
        width: 'auto',
        groupable: false,
        editable: false,
        scrollable: true,
        resizable: true,
        selectable: "single",
        sortable: true,
        filterable: {
            extra: false,
            operators: {
                string: {
                    contains: "Contains",
                    eq: "Equal",
                    neq: "Not Equal"
                }
            }
        },
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                command: [
                    {
                        name: "goToProductView", template: "<span title='Go to Product View' class='bi bi-link' style='cursor: pointer;'></span>&nbsp",
                    }
                ],
                width: 30
            },
            {
                field: "Id",
                title: "Id",
                template: "<span class='goToProduct'>#: id #</span>",
            },
            {
                field: "Uid",
                title: "Uid",
                template: "<span class='text-small'>#: uid #</span>",
            },
            {
                field: "Account",
                title: "Account",
                template: "<span class='text-small'>#: account #</span>",
            },
            {
                field: "Category",
                title: "Category",
                template: "<span class='text-small'>#: category #</span>",
            },
            {
                field: "Currency",
                title: "Currency",
                template: "<span class='text-small'>#: currency #</span>",
            },
            {
                field: "Amount",
                title: "Amount",
                template: "<span class='text-small'>#: amount #</span>",
            },
            {
                field: "Type",
                title: "Type",
                template: "<span class='text-small'>#: type #</span>",
            },
            {
                field: "Date",
                title: "Date",
                template: "<span class='text-small'>#: date #</span>",
            },
            {
                field: "Transfer",
                title: "Transfer",
                template: "<span class='text-small'>#: transfer #</span>",
            },
            {
                field: "Payee",
                title: "Payee",
                template: "<span class='text-small'>#: payee #</span>",
            },
            {
                field: "Labels",
                title: "Labels",
                template: "<span class='text-small'>#: labels #</span>",
            }
        ],
        editable: "popup",
        edit: function (e) {
            e.container.find(".k-edit-label:eq(2)").hide();
            e.container.find(".k-edit-field:eq(2)").hide();
            e.container.find(".k-edit-label:eq(3)").hide();
            e.container.find(".k-edit-field:eq(3)").hide();
        },
    });
});