$(document).ready(function () {

    function showMessage(type, message) {
        var box = $('#message-box');
        box.removeClass("alert-success alert-danger").addClass("alert-" + type);
        box.text(message).fadeIn();

        setTimeout(function () {
            box.fadeOut();
        }, 3000);
    }

    // Buscar aluno e preencher dados
    $(document).on('blur', '.matricula', function () {
        var matricula = $(this).val();
        var row = $(this).closest('tr');

        if (matricula) {
            $.ajax({
                url: '/Aluno/BuscarAlunoPorMatricula',
                method: 'GET',
                data: { matricula: matricula },
                success: function (response) {
                    if (response.dados) {
                        row.find('.nome-aluno').text(response.dados.nome);

                        // Limpa linhas antigas
                        $('#tabela-notas tbody').empty();

                        // Preenche cada matéria do histórico
                        if (response.dados.historico && response.dados.historico.length > 0) {
                            response.dados.historico.forEach(function (h) {
                                var novaLinha = `
                                    <tr data-id="${h.id}">
                                        <td>${response.dados.matricula}</td>
                                        <td>${response.dados.nome}</td>
                                        <td>${h.materia}</td>
                                        <td class="editable" data-field="Nota1">${h.nota1 ?? ''}</td>
                                        <td class="editable" data-field="Nota2">${h.nota2 ?? ''}</td>
                                        <td class="editable" data-field="Nota3">${h.nota3 ?? ''}</td>
                                        <td class="editable" data-field="Nota4">${h.nota4 ?? ''}</td>
                                        <td class="media">${h.media ?? ''}</td>
                                        <td><button class="btn btn-success adicionar">Adicionar</button></td>
                                    </tr>`;
                                $('#tabela-notas tbody').append(novaLinha);
                            });
                        } else {
                            showMessage("danger", "Nenhum histórico encontrado para este aluno.");
                        }
                    } else {
                        row.find('.nome-aluno').text('Aluno não encontrado.');
                    }
                },
                error: function () {
                    showMessage("danger", "Erro ao buscar aluno.");
                }
            });
        } else {
            row.find('.nome-aluno').text('');
        }
    });

    // Atualizar nota e média
    $(document).on("blur", ".editable", function () {
        var linha = $(this).closest('tr');
        var idHistorico = linha.attr('data-id');
        var campo = $(this).attr('data-field');
        var valor = $(this).text();

        if (!valor) return;

        $.post("/Historico/AtualizarNota", { idHistorico: idHistorico, campo: campo, valor: valor }, function (response) {
            if (response.resultado) {
                linha.find('.media').text(response.media);
                showMessage("success", "Alteração salva com sucesso!");
            } else {
                showMessage("danger", "Erro na alteração!");
            }
        }).fail(function () {
            showMessage("danger", "Erro na comunicação com o servidor");
        });
    });

});
