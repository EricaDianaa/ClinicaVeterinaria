$(document).ready(function () {
    // Nascondi il campo NumeroMicrochip all'avvio
  /*  $('#NumeroMicrochip').hide();*/

    // Gestisci l'evento di click sulla checkbox Microchip
    $('#MicrochipCheckbox').change(function () {
        if ($('#MicrochipCheckbox').is(':checked')) {
            $('#NumeroMicrochip').show();
            console.log("Checkbox clicked");
        } else {
            $('#NumeroMicrochip').hide();
        }
    });
});