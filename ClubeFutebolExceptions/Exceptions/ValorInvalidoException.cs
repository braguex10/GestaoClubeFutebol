/*
*	<copyright file="ValorInvalidoException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

namespace ClubeFutebol.Exceptions
{
    public class ValorInvalidoException : DominioException
    {
        public ValorInvalidoException(string campo)
            : base($"Valor inválido para o campo: {campo}.")
        {
        }
    }
}
