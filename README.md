# 💰 Controle de Despesas

Um sistema simples e eficiente para gerenciar suas despesas pessoais, desenvolvido em C# .NET 9.0.

## 📋 Funcionalidades

- ✅ **Adicionar Despesas**: Cadastre novas despesas com descrição, valor e data automática
- ✏️ **Atualizar Despesas**: Modifique informações de despesas existentes
- 🗑️ **Excluir Despesas**: Remova despesas com confirmação de segurança
- 📊 **Visualizar Todas as Despesas**: Liste todas as despesas cadastradas
- 📈 **Resumo Geral**: Visualize estatísticas completas das suas despesas
- 📅 **Resumo Mensal**: Acompanhe gastos do mês atual
- 🏷️ **Categorização**: Organize despesas por categorias
- 💹 **Estatísticas**: Valores totais, médias, maior e menor despesa

## 🚀 Como Executar

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior
- Qualquer editor de código (Visual Studio, VS Code, etc.)

### Executando o Projeto

1. **Clone o repositório**
   ```bash
   git clone https://github.com/SavioFagundes/controledespesa.git
   cd controledespesa
   ```

2. **Compile e execute**
   ```bash
   dotnet run
   ```

   Ou compile primeiro e execute depois:
   ```bash
   dotnet build
   dotnet run
   ```

## 🎮 Como Usar

Ao executar o programa, você verá um menu interativo com as seguintes opções:

```
Controle de Despesas Iniciado

Escolha uma opção:
1. Adicionar Despesa
2. Atualizar Despesa
3. Excluir Despesa
4. Visualizar Todas as Despesas
5. Visualizar Resumo Geral
6. Visualizar Resumo do Mês Atual
7. Sair
```

### 1. Adicionar Despesa
- Digite a descrição/categoria da despesa
- Informe o valor (use vírgula para decimais: 15,50)
- A data atual será registrada automaticamente

### 2. Atualizar Despesa
- Visualize a lista de despesas
- Digite o ID da despesa que deseja modificar
- Atualize a descrição e/ou valor (ou pressione Enter para manter)

### 3. Excluir Despesa
- Visualize a lista de despesas
- Digite o ID da despesa que deseja remover
- Confirme a exclusão digitando 's' ou 'sim'

### 4. Visualizar Todas as Despesas
Exibe todas as despesas no formato:
```
ID: 1 | Categoria: Alimentação | Valor: R$ 45,00 | Data: 05/08/2025
```

### 5. Resumo Geral
Mostra estatísticas completas:
- Total de despesas cadastradas
- Valor total gasto
- Valor médio por despesa
- Maior e menor despesa
- Resumo por categoria

### 6. Resumo do Mês Atual
Apresenta dados específicos do mês corrente:
- Despesas do mês
- Totais e médias mensais
- Categorização mensal

## 🏗️ Estrutura do Projeto

```
ControleDespesas/
├── Models/
│   └── Despesa.cs          # Classe principal com toda a lógica
├── Program.cs              # Ponto de entrada da aplicação
├── ControleDespesas.csproj # Configurações do projeto
├── ControleDespesas.sln    # Solução do Visual Studio
├── .gitignore             # Arquivos ignorados pelo Git
└── README.md              # Este arquivo
```

## 🛠️ Tecnologias Utilizadas

- **C# 12** - Linguagem de programação
- **.NET 9.0** - Framework
- **Console Application** - Interface do usuário
- **LINQ** - Consultas e manipulação de dados
- **Collections Generic** - Armazenamento em memória

## 📊 Funcionalidades Técnicas

### Classe Despesa
A classe `Despesa` implementa:
- **Propriedades**: Id, Categoria, Valor, Data
- **Métodos Estáticos**: Todas as operações CRUD
- **Gerenciamento Automático de IDs**: Incremento automático
- **Armazenamento em Memória**: Lista estática para persistência durante a execução
- **Validações**: Verificações de entrada e dados obrigatórios

### Características do Sistema
- **Interface Intuitiva**: Menu simples e navegação clara
- **Validação de Dados**: Verificação de tipos e valores obrigatórios
- **Confirmações de Segurança**: Confirmação antes de excluir
- **Formatação Monetária**: Valores sempre em formato brasileiro (R$ 0,00)
- **Ordenação Inteligente**: Dados organizados por relevância
- **Tratamento de Erros**: Mensagens claras para entradas inválidas

## 🔮 Melhorias Futuras

- [ ] Persistência em banco de dados
- [ ] Interface gráfica (WPF/WinForms)
- [ ] Exportação para Excel/PDF
- [ ] Categorias pré-definidas
- [ ] Filtros por período personalizado
- [ ] Gráficos e relatórios visuais
- [ ] Backup automático dos dados
- [ ] Múltiplos usuários
- [ ] Integração com APIs bancárias
- [ ] Notificações de gastos

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

**Savio Fagundes**
- GitHub: [@SavioFagundes](https://github.com/SavioFagundes)

## 🤝 Contribuindo

Contribuições são sempre bem-vindas! Para contribuir:

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📞 Suporte

Se você encontrar algum problema ou tiver sugestões, por favor:
- Abra uma [Issue](https://github.com/SavioFagundes/controledespesa/issues)
- Entre em contato através do GitHub

---

⭐ Se este projeto te ajudou, deixe uma estrela no repositório!
