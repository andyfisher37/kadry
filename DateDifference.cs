using System;

namespace kadry.DurationCalculatorApp
{
    public struct TPeriod
    {
        public int d;
        public int m;
        public int y;

        // �������� ��������
        public void Add(int d1, int m1, int y1)
        {
            d = d + d1;
            m = m + m1;
            y = y + y1;
            if (d >= 30) { m++; d = d - 30; }
            if (m >= 12) { y++; m = m - 12; }
        }

        // ������� �������
        public void Clear()
        {
            d = 0;
            m = 0;
            y = 0;
        }

        // �������� �� �������
        public bool isEmpty()
        {
            if (d==0 && m==0 && y==0) return true;
            else return false;
        }

        // �������������� � ����: (00�00�00�)
        public string ToShortString()
        {
            string tmp = "";
            if (y < 10) tmp += String.Format("0{0}�", y);
            else tmp += y.ToString() + "�";
            if (m < 10) tmp += String.Format("0{0}�", m);
            else tmp += m.ToString() + "�";
            if (d < 10) tmp += String.Format("0{0}�", d);
            else tmp += d.ToString() + "�";
            return tmp;
        }

        // �������������� � ����: (00 ��� 00 ������� 00 ����)
        public string ToLongString()
        {
            string tmp = "";
            if (y < 10) tmp += String.Format("0{0} ��� ", y);
            else tmp += y.ToString() + " ��� ";
            if (m < 10) tmp += String.Format("0{0} ������� ", m);
            else tmp += m.ToString() + " ������� ";
            if (d < 10) tmp += String.Format("0{0} ���� ", d);
            else tmp += d.ToString() + " ���� ";
            return tmp;
        }

        // ����������� ���������� � ���� ������: ## ��� ## ������� ## ����
        public string ToSpecString()
        {
            string tmp = "";
            if (y != 0)
            {
                if (y < 10) tmp += String.Format("0{0} ��� ", y);
                else tmp += y.ToString() + " ��� ";
            }
            if (m != 0)
            {
                if (m < 10) tmp += String.Format("0{0} ������� ", m);
                else tmp += m.ToString() + " ������� ";
            }
            if (d != 0)
            {
                if (d < 10) tmp += String.Format("0{0} ����", d);
                else tmp += d.ToString() + " ����";
            }
            return tmp;
        }

        // ����������� ���������� � ���� ������: ## (��������) ��� ## (��������) ������� ## (��������) ����
        public string ToSpecLongString()
        {
            string tmp = "";
            if (y >= 0)
            {
                if (y < 10) tmp += String.Format("0{0} (<i>{1}</i>) ��� ", y, DigToStr("0" + y.ToString()));
                else tmp += String.Format("{0} (<i>{1}</i>) ��� ", y, DigToStr(y.ToString()));
            }
            if (m >= 0)
            {
                if (m < 10) tmp += String.Format("0{0} (<i>{1}</i>) ������� ", m, DigToStr("0" + m.ToString()));
                else tmp += String.Format("{0} (<i>{1}</i>) ������� ", m, DigToStr(m.ToString()));
            }
            if (d >= 0)
            {
                if (d < 10) tmp += String.Format("0{0} (<i>{1}</i>) ����", d, DigToStr("0" + d.ToString()));
                else tmp += String.Format("{0} (<i>{1}</i>) ����", d, DigToStr(d.ToString()));
            }
            return tmp;
        }

        public static string DigToStr(string dig)
        {
            switch (dig)
            {
                case "00": return "����"; break;
                case "01": return "����"; break;
                case "02": return "���"; break;
                case "03": return "���"; break;
                case "04": return "������"; break;
                case "05": return "����"; break;
                case "06": return "�����"; break;
                case "07": return "����"; break;
                case "08": return "������"; break;
                case "09": return "������"; break;
                case "10": return "������"; break;
                case "11": return "�����������"; break;
                case "12": return "����������"; break;
                case "13": return "����������"; break;
                case "14": return "������������"; break;
                case "15": return "����������"; break;
                case "16": return "�����������"; break;
                case "17": return "����������"; break;
                case "18": return "������������"; break;
                case "19": return "������������"; break;
                case "20": return "��������"; break;
                case "21": return "������������"; break;
                case "22": return "�����������"; break;
                case "23": return "�����������"; break;
                case "24": return "��������������"; break;
                case "25": return "������������"; break;
                case "26": return "�������������"; break;
                case "27": return "������������"; break;
                case "28": return "��������������"; break;
                case "29": return "��������������"; break;
                case "30": return "��������"; break;
                case "31": return "������������"; break;
                case "32": return "�����������"; break;
                case "33": return "�����������"; break;
                case "34": return "��������������"; break;
                case "35": return "������������"; break;
                case "36": return "�������������"; break;
                case "37": return "������������"; break;
                case "38": return "��������������"; break;
                case "39": return "��������������"; break;
                case "40": return "�����"; break;
                case "41": return "���������"; break;
                case "42": return "��������"; break;
                case "43": return "��������"; break;
                case "44": return "�����������"; break;
                case "45": return "���������"; break;
                default: return "-"; break;
            }

        }
    }

    public class DateDifference
    {
        /// ������ ���������� ���� � ������� ����; index 0=> ������ and 11=> �������
        /// ������� ����� ��������� 28 ��� 29 ����, ������� ��� �������� -1
        /// ������ ���������� ���� � ������ ������������� �������.

        private readonly int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                
        /// ���� ������ �������
        
        private DateTime fromDate;

        /// ���� ��������� �������
        
        private DateTime toDate;

        /// ���������� ��� ������ ����, ������, ����
        
        private int year;
        private int month;
        private int day;

        public DateDifference(DateTime d1, DateTime d2)
        {
            int increment;
            
           // �������� �� �� ����� �� ��� ������...
            if (d1 > d2)
            {
                fromDate = d2;
                toDate = d1;
            }
            else
            {
                fromDate = d1;
                toDate = d2;
            }

            
            // ���������� ����
             
            increment = 0;

            if (fromDate.Day > toDate.Day)
            {
                increment = monthDay[this.fromDate.Month - 1];

            }
            
            // ���� ����� �������
             
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // �������� �� ���������� ���...
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }

            if (increment != 0)
            {
                day = (toDate.Day + increment) - fromDate.Day;
                increment = 1;
            }
            else
            {
                day = toDate.Day - fromDate.Day;
            }

            
            // ���������� �������
            if ((fromDate.Month + increment) > toDate.Month)
            {
                month = (toDate.Month + 12) - (fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                month = (toDate.Month) - (fromDate.Month + increment);
                increment = 0;
            }

            
            // ���������� ���
            year = toDate.Year - (fromDate.Year + increment);

        }

        // ����������� ���������� � ���� ������: ## ��� ## ������� ## ����
        public override string ToString()
        {
            return String.Format("{0} ���, {1} �������, {2} ����", year, month, this.day);
        }

        // ����������� ���������� � ���� ������: ## (��������) ��� ## (��������) ������� ## (��������) ����
        
       

        public int Years
        {
            get { return year; }
        }

        public int Months
        {
            get { return month; }
        }

        public int Days
        {
            get { return day; }
        }

    }
}
