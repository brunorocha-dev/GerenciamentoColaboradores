$(document).ready(function () {

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 5000)

    // Função para verificar se a data e hora são válidas
    function isValidDateTime(datetime) {
        const date = new Date(datetime);
        const day = date.getDay(); // 0 (domingo) a 6 (sábado)
        const hours = date.getHours();
        const minutes = date.getMinutes();

        // Permitir registro 5 minutos antes das 8h e 5 minutos depois das 18h
        const isWithinGracePeriod = (hours === 7 && minutes >= 55) || (hours === 18 && minutes <= 5);

        return (day !== 0 && day !== 6 && hours >= 8 && hours < 18) || isWithinGracePeriod;
    }

    $("#RegistroEntrada, #RegistroSaida").on("input", function () {
        if (!isValidDateTime(this.value)) {
            this.value = ""; // Limpa o campo se a data/hora for inválida
            alert("Horário inválido. Selecione um horário de segunda a sexta entre 8h e 18h.");
        }
    });

});