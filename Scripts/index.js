Highcharts.setOptions({
    lang: {
        decimalPoint: '.',
        thousandsSep: ','
    }
});

Highcharts.chart('container', {
    data: {
        table: 'datatable'
    },
    chart: {
        type: 'column'
    },
    title: {
        text: ' '
    },
    yAxis: {
        allowDecimals: false,
        title: {
            text: ' '
        }
    },
    legend: {
        padding: 0,
        itemMarginLeft: 0,
        itemMarginRight: 0,
        itemCheckboxStyle: {
            height: "10px"
        },
        itemStyle: {
            fontStyle: "10px",
            zoom: "80%"
        }
    },
    colors: ['#00e600', '#FE2EF7', '#e65c00', '#cebbff', '#A845FF','#ffbf00',
        '#ffb1da', '#fff400', '#AA6739', '#8ef7ff', 
        '#4CAF50', '#ED058B',
        '#a3f2a1', '#79a6d2'/*, '#cc0044'*/],
    plotOptions: {
        series: {
            colorByPoint: true,
            pointPadding: 0.025,
            groupPadding: 0.01,
            borderWidth: 0,
            dataLabels: {
                align: "center",
                verticalAlign: "top",
                inside: false,
                enabled: true,
                format: '{point.y:,.0f}',
                style: {
                    fontSize: '11px',
                    fontFamily: '"Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif'
                }/*,*/
                //allowOverlap: true,
                //useHTML: true,
                //formatter: function () {
                //    var por = this.point[0];
                //    return '<div class="datalabel" style="position: relative; top: 20px"><b>' + this.y + '</div>' +
                //        '<br/>' +
                //        '<div class="datalabelInside" style="position: absolute; top: 30px"><b>' + this.y + '</div>';
                //}
            },
            stackLabels: {
                enabled: true
            }
        }
    },
    tooltip: {
        formatter: function () {
            return '<b>' + this.point.name.toString() + '</b><br/>' +
                this.series.name + ': ' + Highcharts.numberFormat(this.point.y);
        },
        style: {
            fontSize: '12px',
            fontFamily: '"Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif'
        }
    }
});
