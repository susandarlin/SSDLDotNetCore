﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.WinFormsApp.Queries;

public class BlogQuery
{
    public static string CreateQuery { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent])
                            VALUES
                            (@BlogTitle
                            ,@BlogAuthor
                            ,@BlogContent)";
}
