/*
*	<copyright file="DominioException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.Exceptions
{
    public class DominioException : Exception
    {
        public DominioException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
