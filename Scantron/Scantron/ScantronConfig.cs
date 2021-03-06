﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Scantron
{
    class ScantronConfig
    {
        public string port_name { get; set; }
        public int baud_rate { get; set; }
        public Parity parity_bit { get; set; }
        public StopBits stop_bits { get; set; }


        public string start_of_record { get; set; }
        public string end_of_record { get; set; }
        public string end_of_document { get; set; }
        public string compress { get; set; }
        public string record_length { get; set; }
        public string initate { get; set; }
        public string positive { get; set; }
        public string negitive { get; set; }
        public string x_on { get; set; }
        public string x_off { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public string release { get; set; }
        public string select_stacker { get; set; }
        public string download { get; set; }
        public string runtime { get; set; }
        public string status { get; set; }
        public string scanner_control { get; set; }
        public string print_position { get; set; }
        public string print_data { get; set; }
        public string display_data { get; set; }
        public string end_of_info { get; set; }
        public string end_of_batch { get; set; }
        public string ocr { get; set; }

    }
}
