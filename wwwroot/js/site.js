let tamanhoFonte = 100; // percentual inicial
let contrasteAtivo = false; // inicia desligado

function aumentarFonte() {
    if (tamanhoFonte < 200) {
        tamanhoFonte += 10;
        document.body.style.fontSize = tamanhoFonte + "%";
    }
}

function diminuirFonte() {
    if (tamanhoFonte > 50) {
        tamanhoFonte -= 10;
        document.body.style.fontSize = tamanhoFonte + "%";
    }
}

function alternarContraste() {
    contrasteAtivo = !contrasteAtivo;
    document.body.classList.toggle("contraste-ativo", contrasteAtivo);
}
