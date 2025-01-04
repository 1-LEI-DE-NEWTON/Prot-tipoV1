
function toggleExpand(topicId) {
    const content = document.getElementById(topicId);
    if (content.style.display === "block") {
        content.style.display = "none";
    } else {
        content.style.display = "block";
    }
}


function showDetails(statusId) {
    const modal = document.getElementById("modal");
    const modalText = document.getElementById("modal-text");
    
    const messages = {
        validacaoCPF: "A validação do CPF foi realizada com sucesso.",
        cpfJaCliente: "Erro: O CPF informado já está registrado como cliente.",
        validacaoICCID: "A validação do ICCID está em andamento. Aguarde."
    };

    modalText.textContent = messages[statusId] || "Informações não disponíveis.";
    modal.classList.remove("hidden");
}

function closeModal(event) {
    const modal = document.getElementById("modal");
    modal.classList.add("hidden");
    event.stopPropagation();
}
