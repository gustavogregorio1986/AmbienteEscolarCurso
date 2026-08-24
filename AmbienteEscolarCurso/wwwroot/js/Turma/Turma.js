$(document).on("click", ".alunos", function () {
    console.log("Clique detectado em Alunos");
    var idTurma = $(this).data("idturma");
    var nomeTurma = $(this).data("nometurma");
    var tabelaAluno = "";

    $.ajax({
        url: '/Aluno/AlunosDaTurma/' + idTurma,
        type: 'GET',
        success: function (response) {
            if (!response.dados || response.dados.length === 0) {
                tabelaAluno = `
          <tr>
            <td colspan="4">Nenhum aluno na turma</td>
          </tr>
        `;
            } else {
                response.dados.forEach(a => {
                    tabelaAluno += `
            <tr>
              <td>${a.id}</td>
              <td>${a.matricula}</td>
              <td>${a.nome}</td>
              <td>${a.email}</td>
            </tr>
          `;
                });
            }

            document.querySelector('#modalAlunos .modal-body table tbody').innerHTML = tabelaAluno;
            document.getElementById("textModalAlunos").innerText = nomeTurma || "Turma";
            var meuModal = new bootstrap.Modal(document.getElementById("modalAlunos"));
            meuModal.show();
        },
        error: function () {
            alert("Erro ao carregar alunos da turma.");
        }
    });
});
