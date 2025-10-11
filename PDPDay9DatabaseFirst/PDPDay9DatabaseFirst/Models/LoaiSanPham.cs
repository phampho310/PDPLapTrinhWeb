﻿using System;
using System.Collections.Generic;

namespace PDPDay9DatabaseFirst.Models;

public partial class LoaiSanPham
{
    public int Id { get; set; }

    public string MaLoai { get; set; } = null!;

    public string TenLoai { get; set; } = null!;

    public bool TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
