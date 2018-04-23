using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLGridExample.Model {
    public class TestData {
        public string PlainText { get; set; }
        public string MemoText { get; set; }
        public bool BooleanMember { get; set; }
        public ImageSource Image { get; set; }
    }
}
