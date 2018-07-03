using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace ValidaCartao 
{
    public partial class VerificadorCartaoCredito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static bool ValidarNumerosCartao(string numeroCartao)
        {
            try
            {
                // Array para conter os números individuais
                System.Collections.ArrayList numerosChecar = new ArrayList();
                // Pegando o comprimento do cartão informado
                int tamanhoCartao = numeroCartao.Length;


                // Dobrar o valor de dígitos alternativos, começando com o segundo dígito
                // da direita, ou seja, de trás para frente fazendo um loop começando no final
                for (int i = tamanhoCartao - 2; i >= 0; i = i - 2)
                {
                    // Aqui o conteúdo está sendo lido em cada índice,
                    // após será armazenado as informações em uma matriz de inteiros.

                    // Dobrando o valor do número retornado
                    numerosChecar.Add(Int32.Parse(numeroCartao[i].ToString()) * 2);
                }

                int somarNumeros = 0;    // Está variável irá manter a soma total de todos os dígitos

                // Adicionando os dígitos separados
                for (int i = 0; i <= numerosChecar.Count - 1; i++)
                {
                    int contador = 0;    // manterá a soma dos digitos no contador

                    // verificando se o número atual tem mais de um dígito
                    if ((int)numerosChecar[i] > 9)
                    {
                        int tamanhoNumero = ((int)numerosChecar[i]).ToString().Length;
                        // adicionando cada dígito a contagem
                        for (int x = 0; x < tamanhoNumero; x++)
                        {
                            contador = contador + Int32.Parse(
                                  ((int)numerosChecar[i]).ToString()[x].ToString());
                        }
                    }
                    else
                    {
                        // se houver apenas um dígito
                        contador = (int)numerosChecar[i];
                    }
                    somarNumeros = somarNumeros + contador;    // soma total
                }
                // Adicionando todos os dígitos que não tiveram seu valor dobrado,
                // ou seja, começando pelos números à direita dos dígitos alterados.
                int somaNumeroOriginais = 0;
                for (int y = tamanhoCartao - 1; y >= 0; y = y - 2)
                {
                    somaNumeroOriginais = somaNumeroOriginais + Int32.Parse(numeroCartao[y].ToString());
                }

                // Por fim, será realizado o cálculo final que as somas dos números dos valores dobrados e os não Mod 10 
                // com resultado 0 será válido, caso contrário é falso.
                return (((somaNumeroOriginais + somarNumeros) % 10) == 0);
            }
            catch
            {
                return false;
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (ValidarNumerosCartao(txtNumeroCartao.Text))
            {
                lblResultado.Text = Bandeira(txtNumeroCartao.Text) + ": " + txtNumeroCartao.Text + " (válido)";
            }
            else
            {
                lblResultado.Text = Bandeira(txtNumeroCartao.Text) + ": " + txtNumeroCartao.Text + " (inválido)";
            }
        }

        public string Bandeira(string CC)
        {
            string bandeiraCartao;
            string numeroCartao = CC.Substring(0, 2);

            if (int.Parse(numeroCartao) == 34 || int.Parse(numeroCartao) == 37)
            {
                bandeiraCartao = "AMEX";
            }
            else if (int.Parse(numeroCartao) == 60)
            {
                bandeiraCartao = "Discover";
            }
            else if (int.Parse(numeroCartao) >= 51 && int.Parse(numeroCartao) < 56)
            {
                bandeiraCartao = "MasterCard";
            }
            else if (int.Parse(numeroCartao) >= 40 && int.Parse(numeroCartao) < 50)
            {
                bandeiraCartao = "VISA";
            }
            else
            {
                bandeiraCartao = "Desconhecido";
            }

            return bandeiraCartao;
        }
    }
}