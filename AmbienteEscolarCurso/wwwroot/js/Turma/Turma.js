$(document).on("click", ".professores", function () {
    var idTurma = $(this).data("idturma");
    var nomeTurma = $(this).data("nometurma");
    var tabelaProfessor = "";

    $.ajax({
        url: '/Professor/ProfessoresDaTurma/{idTurma}',
        type: 'GET',
        data: { idTurma: idTurma },
        success: function (response) {
            if (response.dados.length === 0) {
                tabelaProfessor = `
                  <tr>
                    <td colspan="4">Nenhum professor vinculado</td>
                  </tr>
                `;
            } else {
                response.dados.forEach(p => {
                    tabelaProfessor += `
                      <tr>
                        <td>${p.id}</td>
                        <td>${p.nome}</td>
                        <td>${p.materia.descricao}</td>
                        <td>${p.email}</td>
                      </tr>
                    `;
                });
            }

            // Preenche o tbody do modal
            document.querySelector('#modalProfessores .modal-body table tbody').innerHTML = tabelaProfessor;

            // Atualiza o título do modal
            document.getElementById("textModalProfessores").innerText = nomeTurma;

            // Exibe o modal
            var meuModal = new bootstrap.Modal(document.getElementById("modalProfessores"));
            meuModal.show();
        },
        error: function () {
            alert("Erro ao carregar professores da turma.");
        }
    });
});
