$(document).ready(function () {
    // Nascondi il campo NumeroMicrochip all'avvio
  /*  $('#NumeroMicrochip').hide();*/


    $('#MicrochipCheckbox input[type="checkbox"]').change(function () {
        if ($(this).prop('checked')) {
            $('#NumeroMicrochip').show();
        } else {
            $('#NumeroMicrochip').hide();
        }
    });

    // Gestisci l'evento di click sulla checkbox Microchip
    //$('#MicrochipCheckbox').change(function () {
    //    if ($('#MicrochipCheckbox').is(':checked')) {
    //        $('#NumeroMicrochip').show();
    //        console.log("Checkbox clicked");
    //    } else {
    //        $('#NumeroMicrochip').hide();
    //        console.log("Checkbox FALSED");
    //    }
    //});
});