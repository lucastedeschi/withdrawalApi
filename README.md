# Withdrawal API

Esse projeto é uma possível resolução do [Backend Intermediate Test](https://github.com/andreariano/interview-tests/blob/master/INTERMEDIATE_TEST2.md) =)

# Execução e testes
Ao executar o projeto **IntermediateTest.Api** será possível visualizar uma página inicial do **Swagger**, que além de exibir detalhes sobre a API, fornece uma ferramenta para realizar requests e visualizar os responses.

# Observações
- Com intuito de substituir possíveis comunicações com outros microsserviços para obter informações dos funcionários, foram criados dados fictícios na classe [GovernmentEmployeeService](https://github.com/lucastedeschi/withdrawalApi/blob/master/Integrations/IntermediateTest.GovernmentSharedFunds/Services/GovernmentEmployees/GovernmentEmployeeService.cs).
- Em alguns lugares foi utilizada uma propriedade chamada **PersonIdentifier**, que nada mais é do que um termo genérico para RG, CPF ou algo do tipo.
