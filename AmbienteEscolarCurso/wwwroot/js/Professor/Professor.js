$(document).on("click", ".professores", function () {
    console.log("Clique detectado em Professores");
    var idTurma = $(this).data("idturma");
    var nomeTurma = $(this).data("nometurma");
    var tabelaProfessor = "";

    $.ajax({
        url: '/Professor/ProfessoresDaTurma/' + idTurma,
        type: 'GET',
        success: function (response) {
            if (!response.dados || response.dados.length === 0) {
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

            document.querySelector('#modalProfessores .modal-body table tbody').innerHTML = tabelaProfessor;
            document.getElementById("textModalProfessores").innerText = nomeTurma || "Turma";
            var meuModal = new bootstrap.Modal(document.getElementById("modalProfessores"));
            meuModal.show();
        },
        error: function () {
            alert("Erro ao carregar professores da turma.");
        }
    });
});
