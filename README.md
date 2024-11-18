# watchNet

Para a criação do serviço, precisamos nos atentar a alguns pontos principais.
Autenticação: Cada plataforma possui seus próprios mecanismos de segurança, exigindo uma gestão cuidadosa das credenciais principalmente nos subníveis do Jira que o serviço precisa acessar.
Sincronização: O serviço precisa rodar em um determinado intervalo para que seja capaz de manter a planilha atualizada com as paginas novas e excluídas.
Escalabilidade: O grande volume de dados pode se tornar um desafio afetando o desempenho do serviço e da planilha em si, talvez tornando necessário armazenamento dos dados em um banco de dados mais complexo.
Erros sistêmicos :A implementação de mecanismos para lidar com falhas e exceções, como erros de conexão ou autenticação, é fundamental para garantir a estabilidade do serviço.
Manutenção: Tanto o Jira quanto o sheets são plataformas vivas com evoluções, o que exigirá uma manutenção constante e sistemas de métricas para verificação da integridade do serviço.
Tendo isto, ainda será necessário realizar etapas de planejamento, desenvolvimento, testes e implantação.
