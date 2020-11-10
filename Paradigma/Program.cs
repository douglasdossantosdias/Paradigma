using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigma
{
    #region Enunciado 1
    #region enun
    /***/
    //    Você receberá um array como uma sequência de pares pai-filho.Por exemplo, a
    //árvore representada pelos pares de nós abaixo:
    //[A, B]
    //    [A, C]
    //    [B, G]
    //    [C, H]
    //    [E, F]
    //    [B, D]
    //    [C, E]
    //    Pode ser ilustrado de várias maneiras, com duas possíveis representações abaixo:

    //A
    /// \
    //B C
    /// \ / \
    //G D E H
    //\
    //F

    //A
    /// \
    //B C
    /// \ / \
    //D G H E
    ///
    //F

    //Deverá ser lançada uma exceção caso não seja possível construir a árvore:
    //Código Erro
    //E1 Mais de 2 filhos
    //E2 Ciclo presente
    //E3 Raízes múltiplas
    //E4 Qualquer outro erro

    //A saída para nosso método será a seguinte:
    //Exemplo 1
    //Entrada: [A, B]
    //    [A, C]
    //    [B, G]
    //    [C, H]
    //    [E, F]
    //    [B, D]
    //    [C, E]
    //    Saída: A[
    //    [B[D][G]]
    //    [C[E[F]][H]]]
    //]
    //Exemplo 2
    //Entrada: [B, D]
    //    [D, E]
    //    [A, B]
    //    [C, F]
    //    [E, G]
    //    [A, C]

    //    Saída: A[
    //    [B[D[E[G]]]]
    //    [C[F]]
    //]
    //Exemplo 3
    //Entrada: [A, B]
    //    [A, C]
    //    [B, D]
    //    [D, C]
    //    Saída: Exceção E3

    /***/
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var arvoreParametro1 = new char[][] {
               new [] {'A','B'},
               new [] {'A','C'},
               new [] {'B','G'},
               new [] {'C','H'},
               new [] {'E','F'},
               new [] {'B','D'},
               new [] {'C','E'}
            };

            var arvoreParametro2 = new char[][] {
                new [] {'B','D'},
                new [] {'D','E'},
                new [] {'A','B'},
                new [] {'C','F'},
                new [] {'E','G'},
                new [] {'A','C'}
            };

            var arv1 = ConstroiArvore(arvoreParametro1);
            var arv2 = ConstroiArvore(arvoreParametro2);
        }

        public static No ConstroiArvore(char[][] arvore, char raiz = '\0')
        {

            var arvoreResultado = new No();

            if (raiz == '\0')
            {
                foreach (var par in arvore)
                {
                    arvoreResultado.Raiz = arvoreResultado.Raiz.CompareTo(par[0]) > 0 || arvoreResultado.Raiz == 0
                        ? par[0] : arvoreResultado.Raiz;
                }

            }
            else
            {
                arvoreResultado.Raiz = (char)raiz;
            }


            var nos = arvore
                .Where(x => x[0] == arvoreResultado.Raiz)
                .OrderBy(x => x[0])
                .ToArray()[0];

            if (nos.Length > 2)
            {
                Console.WriteLine(Excecoes.E1.ToString());
                return null;
            }

            if (nos.Length <= 0)
            {
                arvoreResultado.FolhaEsquerda = new No { Raiz = raiz };
                arvoreResultado.FolhaDireita = new No { Raiz = raiz };
            }
            else
            {
                arvoreResultado.FolhaEsquerda = ConstroiArvore(arvore, nos[0]);
                arvoreResultado.FolhaEsquerda = nos.Length == 1
                    ? null
                    : ConstroiArvore(arvore, nos[1]);
            }

            return arvoreResultado;

        }

        public enum Excecoes
        {
            /// <summary>
            /// Mais de 2 filhos
            /// </summary>
            E1,

            /// <summary>
            /// Ciclo presente
            /// </summary>
            E2,

            /// <summary>
            /// Raízes múltiplas
            /// </summary>
            E3,

            /// <summary>
            /// Qualquer outro erro
            /// </summary>
            E4
        }
    }

    public class No
    {
        public char Raiz { get; set; }
        public No FolhaEsquerda { get; set; }
        public No FolhaDireita { get; set; }
    }
    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 2
    // O que é Reflection e em quais casos usar?
    //-R- O namespace System.Reflection contém várias classes que implementam métodos que são capazes de refletir
    //metadados através de objetos, com isso, podemos, em tempo de execução, saber quais propriedades uma classe 
    //possui, os tipos dessas propriedades, também conseguimos consultar quais os eventos e interfaces que uma class 
    //implementa, etc.
    //   Alguns casos para usar reflection:
    //       -- Criar query’s dinamicamente;
    //       -- Serializar dados.
    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 3
    // O que são generics no C# .Net?
    //-R-   Generics permite que tenhamos algoritmos que possam ser aplicados independentes de tipo. Ou seja, criamos um código cujo parâmetroé o tipo ao qual ele é aplicado. O uso mais comum de Generics está em algoritmos para implementação de coleções.
    //Usando Generics podemos reutilizar um classe ou método evitando a repetição de código desnecessário. Estamos aderente ao princípio DRY - não se repita.
    //A utilização de classes genéricas também permite que você crie uma classe que é segura na compilação; isso significa que você pode ter certeza do tipo de objeto e pode usar a classe de forma específica sem obter um comportamento inesperado.
    //Além disso você escreve menos código devido a reutilização.

    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 4
    // O que deve ser feito para o método abaixo funcionar corretamente?
    //     public T ExportarDados<T>()
    // {
    //     T retorno = new T();
    //      .
    //      .
    //      .
    //      return retorno;
    // }

    //-R-    
    //public T ExportarDados<T>() where T : new()
    //{
    //    T retorno = new T();
    //              .
    //              .
    //              .
    //   return retorno;
    //}


    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 5
    // A tabela de funcionários possui todos os funcionários.Todo empregado tem um Id, um
    //    salário, e também há uma coluna para o ID do departamento.
    //         +----+-------+--------+--------------+
    //         | Id | Nome | Salario| DeptID |
    //         +----+-------+--------+--------------+
    //         | 1 | Joe | 70000 | 1 |
    //         | 2 | Henry | 80000 | 2 |
    //         | 3 | Sam | 60000 | 2 |
    //         | 4 | Max | 90000 | 1 |
    //         +----+-------+--------+--------------+

    //        A tabela do Departamento possui todos os departamentos da empresa.
    //         +----+----------+
    //         | Id | Nome |
    //         +----+----------+
    //         | 1 | IT |
    //         | 2 | Sales |
    //         +----+----------+

    //        Escreva uma consulta SQL para encontrar funcionários que tenham o salário mais alto em
    //        cada um dos departamentos.Para as tabelas acima, Max tem o salário mais alto no
    //        departamento de TI e Henry tem o salário mais alto no departamento de vendas.
    //         +--------------+----------+--------+
    //         | Departamento | Empresa | Salario|
    //         +--------------+----------+--------+
    //         | IT | Max | 90000 |
    //         | Sales | Henry | 80000 |
    //         +--------------+----------+--------+
    //    SELECT D.Nome as Departamento, F.Nome as Empresa, F.Salario as Salário
    //    FROM Funcionarios F INNER JOIN
    //    Departamento D
    //    ON F.DeptID = D.ID
    //    WHERE Salario IN (SELECT MAX(Salario) FROM Funcionarios GROUP BY DeptID)
    //    ORDER BY DeptID

    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 6
    //Qual é o uso do método.each ()? De um exemplo.
    //O método jQuery each nos provê uma forma simples e fácil de percorrer diferentes tipos de coleções DOM no HTML.A coleção pode ser do tipo objeto jQuery ou arrays.Se você já viu ou usou algum tipo de for each loop em alguma linguagem de programação, o método jQuery each é igual a eles.

    //Exemplo:
    //HTML
    //    <ul>
    // <li><a src = "/home" > Home </ a ></ li >
    // < li >< a src="/contato">Contato</a></li>
    // <li><a src = "/sobre" > Sobre </ a ></ li >
    //</ ul >
    //< button > Clicar </ button >
    //js
    //   $("button").click(function(){
    //    $("li").each(function(){
    //           alert($(this).text());
    //       });
    //   });

    //  Como pode ver no exemplo anterior, no clique do botão eu chamo o método $(seletor).each. No método each, o seletor é o elemento <li>.       Em seguida chamo um alerta (alert) que irá exibir o texto de cada <li>.
    //   O alert irá mostrar o texto de cada item da lista usando a propriedade.text.E ainda poderá ver que o alert irá ser exibido três vezes,      um para cada<li> do menu.
    ////******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 7
    //O que o código abaixo irá fazer?
    //     $("div").css( "width", "300px" ).add("p").css("background-color", "blue");
    //O código js acima definirá a largura de todos os DIVs disponíveis para 300px e definirá a cor de fundo de todos os DIVs e tags P disponíveis para AZUL .

    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 8
    // Explique MVC(Model-View-Controller)?
    //    MVC é um padrão de projeto usado para desacoplar a interface do usuário(View), os dados(model) e a lógica do aplicativo(controller). Esse padrão ajuda a conseguir a separação de interesses.
    //Usando o padrão MVC para projetos, as solicitações são encaminhadas para um Controlador(Controller) que é responsável por trabalhar com o Modelo(Model) para realizar ações e / ou recuperar dados. O Controlador escolhe a Visualização(View) a ser exibida e a fornece com o Modelo(Model).A Visualização(View) renderiza a página final, com base nos dados do Modelo(Model).

    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 9
    // O que é partial view? De um exemplo de uso.
    //Algumas vezes você vai se deparar com a necessidade de reutilizar códigos de suas visões em suas aplicações, um conceito muito utilizado nestas situações são as visões parciais(partial view), com este recurso você pode quebrar sua visão em vários pedaços, como por exemplo utilizando uma visão parcial para o cabeçalho, outra para o rodapé e qualquer parte de sua aplicação conforme a sua necessidade. Entretanto você também pode utilizar as visões parciais para reutilizar código de um modo mais avançado, como por exemplo reutilizar o código de um iterador utilizando apenas a parte a ser iterada, separando o iterando do resultado mostrado.

    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 10
    // Como restringir o acesso ao método do Web API com HTTP Verb?
    //     public void AlterarUsuario(Usuario usuario)
    // {
    //     UsuarioRepository.AddUsuario(usuario);
    // }


    //     para restringir o acesso para ações específicas, adicione o atributo ao método de ação:
    //     [Authorize]
    //     public void AlterarUsuario(Usuario usuario)
    // {
    //     UsuarioRepository.AddUsuario(usuario);
    // }
    //******************************************************************************************************************************
    //******************************************************************************************************************************
    #endregion
    #region Enunciado 11
    // O que é o OData usado ASP.NET Web API?
    // OData (Open Data Protocolo) é um protocolo criado pela Microsoft para facilitar a criação e consumo de web services RESTful. Seu objetivo é definir padrões de como os serviços devem funcionar, a fim de permitir que os clientes os consumissem com facilidade, uma vez que estarão lidando com uma aplicação que segue uma padronização amplamente utilizada.

    // Por exemplo, esse protocolo define como deve ser a URL para realização de certas operações, como filtros e ordenação.Neste exemplo instalaremos um pacote via NuGet para implementar esses recursos de consulta seguindo o padrão OData.
    #endregion


}
