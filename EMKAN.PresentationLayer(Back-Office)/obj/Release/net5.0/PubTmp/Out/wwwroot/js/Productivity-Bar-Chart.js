var NameLists = [];

var urlPath = mvcBaseUrl + 'Employee/ViewEmployeeAction';
function DrawBarChart() {
   
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: urlPath,
        success: function (data) {

            for (var i = 0; i < data.length; i++) {
        
                NameLists.push(data[i].FirstName + " " + data[i].LastName)
            }
            DrawBar(data);
        }
       });
}


function DrawBar(data) {
    
    if ($('#chartjs_bar').length) {
        var ctx = document.getElementById("chartjs_bar").getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: NameLists
               ,
                datasets: [{
                    label: 'Open',
                    data: [12, 19, 3, 17, 28, 24, 7],
                    backgroundColor: "rgba(76,93,112)",
                    borderWidth: 2
                }, {
                    label: 'Closed',
                    data: [30, 29, 5, 5, 20, 3, 10],
                    backgroundColor: "rgba(248,131,121)",
                    borderWidth: 2
                }]
            },
            options: {
                scales: {
                    yAxes: [{

                    }]
                },
                legend: {
                    display: true,
                    position: 'bottom',

                    labels: {
                        fontColor: '#71748d',
                        fontFamily: 'Circular Std Book',
                        fontSize: 14,
                    }
                },

                scales: {
                    xAxes: [{
                        ticks: {
                            fontSize: 14,
                            fontFamily: 'Circular Std Book',
                            fontColor: '#71748d',
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            fontSize: 14,
                            fontFamily: 'Circular Std Book',
                            fontColor: '#71748d',
                        }
                    }]
                }
            }


        });
    }
}