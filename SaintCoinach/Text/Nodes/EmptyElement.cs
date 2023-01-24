﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintCoinach.Text.Nodes {
    public class EmptyElement : INode {
        private readonly TagType _Tag;
        private readonly String _LenByte;

        public TagType Tag { get { return _Tag; } }
        public String LenByte { get { return _LenByte; } }
        NodeFlags INode.Flags { get { return NodeFlags.IsStatic; } }

        public EmptyElement(TagType tag, String lenByte) {
            _Tag = tag;
            _LenByte = lenByte;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }
        public void ToString(StringBuilder builder) {
            builder.Append(StringTokens.TagOpen);
            builder.Append("hex:02");
            builder.Append(((byte)Tag).ToString("X2")); /* X means hex, 2 means 2-digit */
            builder.Append(LenByte);
            builder.Append("03");
            builder.Append(StringTokens.TagClose);
        }

        public T Accept<T>(SaintCoinach.Text.Nodes.INodeVisitor<T> visitor) {
            return visitor.Visit(this);
        }
    }
}
