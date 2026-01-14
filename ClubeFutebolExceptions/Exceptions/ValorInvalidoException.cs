/*
*	<copyright file="ValorInvalidoException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

namespace ClubeFutebol.Exceptions
{
    /// <summary>
    /// Explicação de que o valor não é válido para a execução de um processo
    /// </summary>
    public class ValorInvalidoException : DominioException
    {
        public ValorInvalidoException(string campo)
            : base($"Valor inválido para o campo: {campo}.")
        {
        }
    }
}
