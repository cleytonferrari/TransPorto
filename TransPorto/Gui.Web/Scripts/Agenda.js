function AgendaViewModel() {
    var self = this;
    self.id = ko.observable('');
    self.listaAgenda = ko.observableArray([]);
    self.veiculo = ko.observableArray([]);
    self.motorista = ko.observableArray([]);
    self.passageiro = ko.observableArray([]);
    self.dataAgendamento = ko.observable('');
    self.origemDestino = ko.observable('');
    self.buscar = ko.observable('');
    self.companhiaAerea = ko.observable([]);

self.salvar = function () {
    var agendaSalvar = {
        Veiculo: {
            Modelo: self.veiculo.Modelo(),
        },
        Motorista: {
            Nome: self.motorista.Nome()
        },
        Passageiro: {
            Nome: self.passageiro.Nome()
        },
        DataAgenda: self.dataAgendamento(),
        OrigemDestino: self.origemDestino(),
        Buscar: self.buscar(),
        CompanhiasAereas: self.companhiaAerea.Nome()
    };
    salvarNovaAgenda(agendaSalvar);
};

self.carregaAlterar = function(agenda) {
    self.id(agenda.Id);
    self.veiculo.Modelo(agenda.veiculo.Modelo);
    self.motorista.Nome(agenda.motorista.Nome);
    self.passageiro.Nome(agenda.passageiro.Nome);
    self.dataAgendamento(agenda.DataAgenda);
    self.origemDestino(agenda.OrigemDestino);
    self.buscar(agenda.Buscar);
    self.companhiaAerea.Nome(agenda.companhiaAerea.Nome);
};

self.alterar = function () {
    var agendaSalvar = {
        Id: self.id(),
        Veiculo: {
            Modelo: self.veiculo.Modelo(),
        },
        Motorista: {
            Nome: self.motorista.Nome()
        },
        Passageiro: {
            Nome: self.passageiro.Nome()
        },
        DataAgenda: self.dataAgendamento(),
        OrigemDestino: self.origemDestino(),
        Buscar: self.buscar(),
        CompanhiasAereas: self.companhiaAerea.Nome()
    };
    alterarAgenda(agendaSalvar);
};

self.excluir = function (agenda) {
    deletarAgenda(agenda);
};

self.listar = function () {
    listarAgenda();
};

function listarAgenda() {
    return ajaxRequest("get", agendaUrl())
        .done(getSucceeded)
        .fail(getFailed);

    function getSucceeded(data) {
        self.listaDeAgenda([]);
        var array = self.listaDeAgenda();
        ko.utils.arrayPushAll(array, data);
        self.listaDeAgenda.valueHasMutated();
    }

    function getFailed() {
        self.mensagem("Erro ao receber lista de agendas.");
    }
}

function deletarAgenda(agenda) {
    return ajaxRequest("delete", agendaUrl(agenda.Id))
        .done(function (result) {
            //exibe um salvo com sucesso
            self.mensagem("Registro Excluido com sucesso!");
            listarAgenda();
        })
        .fail(function () {
            //exibe um erro
            self.mensagem("Erro ao alterar nova agenda.");
        });
}

function alterarAgenda(agenda) {
    return ajaxRequest("put", agendaUrl(agenda.Id), agenda, "text")
        .done(function (result) {
            console.log(result);
            //exibe um salvo com sucesso
            self.mensagem("Registro Alterado com sucesso!");
            listarAgenda();
            self.limparTela();
        })
        .fail(function () {
            //exibe um erro
            self.mensagem("Erro ao alterar nova agenda.");
        });
}

function salvarNovaAgenda(agenda) {
    return ajaxRequest("post", agendaUrl(), agenda)
        .done(function (result) {
            console.log(result);
            //exibe um salvo com sucesso
            self.mensagem("Registro Salvo com sucesso!");
            listarAgenda();
            self.limparTela();
        })
        .fail(function () {
            //exibe um erro
            self.mensagem("Erro ao adicionar nova agenda.");
        });
}

function ajaxRequest(type, url, data, dataType) { // Ajax helper
    var options = {
        dataType: dataType || "json",
        contentType: "application/json",
        cache: false,
        type: type,
        data: JSON.stringify(data)
    };
    return $.ajax(url, options);
}
        
// rotas
function agendaUrl(id) { return "Painel/Agenda/" + (id || ""); }

};

var viewModel = new AgendaViewModel();

viewModel.listar();

$(document).ready(function () {
    ko.applyBindings(viewModel);
});