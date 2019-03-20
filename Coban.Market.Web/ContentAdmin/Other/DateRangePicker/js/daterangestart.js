$(document).ready(function () {
    $(function () {
        $('input[name="daterange"]').daterangepicker({
            opens: 'left',
            "locale": {
                "format": "DD/MM/YYYY",
                "separator": " - ",
                "applyLabel": "Onayla",
                "cancelLabel": "İptal",
                "fromLabel": "Nerden",
                "toLabel": "Nereye",
                "customRangeLabel": "Özel",
                "daysOfWeek": [
                    "Pzr",
                    "Pzrts",
                    "Salı",
                    "Çrşmb",
                    "Prşm",
                    "Cuma",
                    "Cmrts"
                ],
                "monthNames": [
                    "Ocak",
                    "Şubat",
                    "Mart",
                    "Nisan",
                    "Mayıs",
                    "Haziran",
                    "Temmuz",
                    "Ağustos",
                    "Eylül",
                    "Ekim",
                    "Kasım",
                    "Aralık"
                ],
                "firstDay": 1
            }
        }, function (start, end, label) {
            console.log("Seçtiğiniz Tarih: " + start.format('DD-MM-YYYY') + ' to ' + end.format('DD-MM-YYYY'));
            $("#first").val(start.format('DD-MM-YYYY'));
            $("#last").val(end.format('DD-MM-YYYY'));
        });
    });
});


