
function openTab(id) {
    const tagChild = document.querySelector("#" + id + ' ul')
    if (tagChild != null) {
        const iconNext = document.querySelector("#" + id + ' .icon-next')
        var value = tagChild.getAttribute('myname')
        if (value == 'False') {
            tagChild.classList.remove('display-tag-none');
            tagChild.classList.add('display-tag-block');
            tagChild.setAttribute("myname", "True");
            iconNext.classList.add('rotate-in')

        } else {
            tagChild.classList.remove('display-tag-block');
            tagChild.classList.add('display-tag-none');
            tagChild.setAttribute("myname", "False");
            iconNext.classList.remove('rotate-in')
        }
    }

}
function loadStarted(id) {

    const tagName = document.getElementById(id);
    if (tagName != null) {
        const tagChild = tagName.firstElementChild;
        const tagChildSpan = tagChild.firstElementChild;
        const tagChildIcon = tagChildSpan.firstElementChild;
        const tagSecondChildSpan = tagChild.children[1];

        const tagDel = document.querySelector('.setBackGroundMenu');
        const tagChildDel = document.querySelector('.setBackGroundChildMenu');

        const tagSpanDel = document.querySelectorAll('.navColor');
        const tagIcondel = document.querySelector('.navTransform');

        //hủy màu
        tagSpanDel.forEach(element => {
            $(element).removeClass("navColor");
        });
        $(tagIcondel).removeClass("navTransform");


        $(tagDel).removeClass("setBackGroundMenu");
        $(tagChildDel).removeClass("setBackGroundChildMenu");

        //thêm màu
        $(tagChildSpan).addClass("navColor");
        $(tagChildIcon).addClass("navTransform");
        $(tagSecondChildSpan).addClass("navColor");
        $(tagName).addClass("setBackGroundMenu");
        $(tagChild).addClass("setBackGroundChildMenu");
    }
}
loadStarted('load');
openTab('openTab');
// window.onload = function() {

//     var chart = new CanvasJS.Chart("chartContainer", {
//         animationEnabled: true,
//         title: {
//             text: "Desktop Search Engine Market Share - 2016"
//         },
//         data: [{
//             type: "pie",
//             startAngle: 240,
//             yValueFormatString: "##0.00\"%\"",
//             indexLabel: "{label} {y}",
//             dataPoints: [
//                 {y: 79.45, label: "Google"},
//                 {y: 7.31, label: "Bing"},
//                 {y: 7.06, label: "Baidu"},
//                 {y: 4.91, label: "Yahoo"},
//                 {y: 1.26, label: "Others"}
//             ]
//         }]
//     });
//     chart.render();

//     }


window.onload = function () {

    var chart = new CanvasJS.Chart("canvas_chart", {
        exportEnabled: true,
        backgroundColor: "#ccc",
        animationEnabled: true,
        title: {
            text: "Biểu đồ thống kê doanh thu"
        },
        legend: {
            cursor: "pointer",
            itemclick: explodePie
        },
        data: [{
            type: "pie",
            showInLegend: true,
            toolTipContent: "{name}: <strong>{y}%</strong>",
            indexLabel: "{name} - {y}%",
            dataPoints: [
                { y: 50, name: "Iphone11", exploded: true },
                { y: 50, name: "SamSunggalaxy" },

            ]
        }]
    });
    chart.render();
}



function explodePie(e) {
    if (typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
    } else {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
    }
    e.chart.render();

}
const logOut = document.querySelector('.author-logout i');
const end = document.querySelector('.log-out');
var tagLog = false;

$('body').click(function () {
    if (tagLog) {
        end.style.display = 'block';
        tagLog = false;
    } else {
        end.style.display = 'none';
    }

})
$(logOut).click(function () {
    if (tagLog)
        tagLog = false;
    else
        tagLog = true;
})
$('.btn-add').click(function () {
    const add = document.querySelector('.form-add');
    add.style.display = 'flex';
})
$('.BillDetails').click(function () {
    const add = document.querySelector('.form-add');
    add.style.display = 'flex';
})
$('.out').click(function () {
    const add = document.querySelector('.form-add');
    add.style.display = 'none';
})
function readUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('.update-image')
                .attr('src', e.target.result)
                .width(150)
                .height(150);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
