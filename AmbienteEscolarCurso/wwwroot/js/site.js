$(document).ready(function () {
    // Aplica DataTables em todas as tabelas com a classe 'datatable'
    $('#registros').DataTable({
        language: {
            sLengthMenu: "Mostrar _MENU_ registros por página",
            sZeroRecords: "Nenhum registro encontrado",
            sProcessing: "Processando...",
            sSearch: "Pesquisar",
            oPaginate: {
                sNext: "Próximo",
                sPrevious: "Anterior",
                sFirst: "Primeiro",
                sLast: "Último"
            },
            oAria: {
                sSortAscending: ": Ordenar colunas de forma ascendente",
                sSortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
});
