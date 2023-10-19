$(document).ready(function () {
    $("#Cerca1").click(function () {
        var valore = $("#Input1").val()
        console.log(valore)
        $.ajax({
            method: "POST",
            url: "RicercaAnimale1",
            data: { NumeroMicrochip: valore },
            success: function (data) {
                console.log(data)
                if (data.length > 0) {
                    $.each(data, function (i, v) {
                        var Foto;
                        if (v.Foto == null) {
                            Foto = "<img src='https://www.comune.marzabotto.bo.it/servizi/funzioni/download.aspx?id=4148&idc=2764' class='img-fluid' />";
                        }
                        else {
                            Foto = "<img src='/Content/ImgProgetto/" + v.Foto + "' class='img-fluid'/>"
                        }

                        var DatiP
                        if (v.NomeProprietario != "") {
                            DatiP = "<p><strong>Dati proprietario: </strong>" + v.NomeProprietario + " " + v.CognomeProprietario + "</p>";
                        }
                        else {
                            DatiP = "  <p>Proprietario non identificato o appartenente al comune</p>";
                        }

                        var licurrent =
                            "  <div class='d-flex flex-column text-center'>" +
                            " <div class='row'>" +
                            " <div class=' mb-4 rounded-3 bg-info border border-info mt-4'>" +
                            " <div class='card'>" +
                            " <h2 class='text-center'>Dettagli</h2>" +
                            " <div class='bg-image hover-overlay ripple' data-mdb-ripple-color='light'>"
                            + Foto
                            + " <a href='#!'>" +
                            " <div class='mask' style='background-color: rgba(251, 251, 251, 0.15);'></div></a>  </div>" +
                            "  <div class='card-body'>" +
                            "  <p class='card-title'><strong>Nome animale: </strong>" + v.Nome + "</p>" +
                            "<div class='card-text'>" +
                            DatiP +
                            " <p><strong>Data di nascita: </strong>" + v.DataNascitaString + "</p>" +
                            "<p> <strong>Data inizio ricovero: </strong>" + v.DataInizioRicoveroString + "</p > " +
                            "<p><strong>Colore del pelo: </strong>" + v.ColoreMantello + "</p>" +
                            "<p><strong>Tipologia: </strong>" + v.TipologiaNome + "</p>" +
                            "</div>" +
                            "</div>" +
                            "</div>" +
                            " </div>" +
                            " </div>" +
                            "</div>"
                        $("#List1").html(licurrent);
                        $("#List2").html("");

                        $.ajax({
                            method: "GET",
                            url: "RicercaAnimale2",

                            success: function (data) {
                                $("#List").html("")
                                console.log("Visite", data)
                                if (data.length > 0) {
                                    $.each(data, function (index, v) {
                                        var licurrent = " <div class='d-flex flex-column mt-4'>" +
                                            "<h2 class='text-center text - black'>Visite</h2>" +
                                            "<table class='table table-bordered border-dark'>" +
                                            "<thead>" +
                                            "<tr class='bg-info'>" +
                                            "<th scope='col'></th>" +
                                            "<th scope='col'>Data visita</th>" +
                                            "<th scope='col'>Descrizione</th></tr></thead> <tbody><tr>" +
                                            "<th scope='row' class='bg-info'>" + v.idVisite + "</th>" +
                                            "<td>" + v.DataString + "</td>" +
                                            "<td>" + v.Descrizione + "</td></tr></tbody></table></div>";
                                        $("#List").append(licurrent)
                                    });
                                }
                                else {
                                    $("#List").html("<h2 class='text-center border border-dark bg-info mt-4 p-3 '>Nessuna visita per il paziente</h2>");
                                }
                            }
                        })
                    })
                }
                else {
                    $("#List1").html("<h2 class='text-center border border-dark bg-info mt-4 p-3 '>Nessun risultato trovato</h2>");
                    $("#List").html("");
                }
            }
        })
    })

    //$("#Cerca1").click(function () {
    //$.ajax({
    //    method: "GET",
    //    url: "RicercaAnimale2",

    //    success: function (data) {
    //        $("#List").html("")
    //        console.log("Visite", data)
    //        if (data.length > 0) {
    //            $.each(data, function (index, v) {
    //                var licurrent = " <div class='d-flex flex-column mt-4'>" +
    //                    "<h2 class='text-center text - black'>Visite</h2>" +
    //                    "<table class='table table-bordered border-dark'>" +
    //                    "<thead>" +
    //                    "<tr class='bg-info'>" +
    //                    "<th scope='col'></th>" +
    //                    "<th scope='col'>Data visita</th>" +
    //                    "<th scope='col'>Descrizione</th></tr></thead> <tbody><tr>" +
    //                    "<th scope='row' class='bg-info'>" + v.idVisite + "</th>" +
    //                    "<td>" + v.DataString + "</td>" +
    //                    "<td>" + v.Descrizione + "</td></tr></tbody></table></div>";
    //                $("#List").append(licurrent)
    //            });
    //        }
    //        else {
    //            $("#List").html("<h2 class='text-center border border-dark bg-info mt-4 p-3 '>Nessuna visita per il paziente</h2>");
    //        }
    //    }
    //})
    //})
})