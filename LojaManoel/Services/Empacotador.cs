using LojaManoel.Modelos;

namespace LojaManoel.Services
{
    public class Empacotador
    {
        private List<Caixa> caixasDisponiveis = new List<Caixa>
        {
            new Caixa { Caixa_Id = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Caixa_Id = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Caixa_Id = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };

        public List<Caixa> Empacotar(List<Produto> produtos)
        {
            // Lista para almacenar las cajas usadas en este pedido
            List<Caixa> caixasUsadas = new List<Caixa>();

            // Iterar sobre cada producto
            foreach (var produto in produtos)
            {
                bool produtoEmpacotado = false;

                // Intentar empacar el producto en una caja existente
                foreach (var caixa in caixasUsadas)
                {
                    if (ProdutoCabeNaCaixa(produto, caixa))
                    {
                        caixa.Produtos.Add(produto.Produto_Id);
                        produtoEmpacotado = true;
                        break; // Producto empacado, salir del loop
                    }
                }

                // Si no cabe en ninguna caja existente, crear una nueva caja
                if (!produtoEmpacotado)
                {
                    var novaCaixa = SelecionarCaixaAdequada(produto);
                    if (novaCaixa != null)
                    {
                        novaCaixa.Produtos.Add(produto.Produto_Id);
                        caixasUsadas.Add(novaCaixa);
                    }
                    else
                    {
                        // Si no hay ninguna caja adecuada, agregar una observación
                        caixasUsadas.Add(new Caixa
                        {
                            Caixa_Id = null,
                            Produtos = new List<string> { produto.Produto_Id },
                            Observacao = "Produto não cabe em nenhuma caixa disponível."
                        });
                    }
                }
            }

            return caixasUsadas;
        }

        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            // Verificar si el producto cabe en la caja comparando volumen o dimensiones
            // Aquí asumimos que los productos pueden rotar dentro de la caja para maximizar el uso del espacio.
            return produto.Dimensoes.Altura <= caixa.Altura &&
                   produto.Dimensoes.Largura <= caixa.Largura &&
                   produto.Dimensoes.Comprimento <= caixa.Comprimento;
        }

        private Caixa SelecionarCaixaAdequada(Produto produto)
        {
            var caixasDisponiveis = new List<Caixa>
            {
                new Caixa { Caixa_Id = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80, Produtos = new List<string>() },
                new Caixa { Caixa_Id = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40, Produtos = new List<string>() },
                new Caixa { Caixa_Id = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60, Produtos = new List<string>() }
            };

            // Buscar la caja más pequeña en la que el producto quepa
            foreach (var caixa in caixasDisponiveis)
            {
                if (ProdutoCabeNaCaixa(produto, caixa))
                {
                    return caixa;
                }
            }

            // Si ningún producto cabe, devolver null
            return null;
        }

    




    }

}
