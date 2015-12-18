function openModal(){
    $('#modal_eliminar').modal('show');
}

function openModal1() {
    $('#modal_especial1').modal('show');
}

function closeModal() {
    $('#modal_eliminar').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

function closeModal1() {
    $('#modal_especial1').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}