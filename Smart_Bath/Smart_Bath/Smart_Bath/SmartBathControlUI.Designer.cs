namespace Smart_Bath
{
    partial class SmartBathControlUI
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartBathControlUI));
            this.textBoxST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTS = new System.Windows.Forms.TextBox();
            this.textBoxWS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOn = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOff = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRxdData = new System.Windows.Forms.ListBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxST
            // 
            this.textBoxST.Location = new System.Drawing.Point(171, 154);
            this.textBoxST.Name = "textBoxST";
            this.textBoxST.Size = new System.Drawing.Size(171, 21);
            this.textBoxST.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(79, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "온도 설정 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label2.Location = new System.Drawing.Point(79, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "현재 온도 : ";
            // 
            // textBoxGT
            // 
            this.textBoxGT.Enabled = false;
            this.textBoxGT.Location = new System.Drawing.Point(171, 20);
            this.textBoxGT.Name = "textBoxGT";
            this.textBoxGT.Size = new System.Drawing.Size(171, 21);
            this.textBoxGT.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(49, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "설정 온도 : ";
            // 
            // textBoxTS
            // 
            this.textBoxTS.Enabled = false;
            this.textBoxTS.Location = new System.Drawing.Point(171, 65);
            this.textBoxTS.Name = "textBoxTS";
            this.textBoxTS.Size = new System.Drawing.Size(171, 21);
            this.textBoxTS.TabIndex = 5;
            // 
            // textBoxWS
            // 
            this.textBoxWS.Enabled = false;
            this.textBoxWS.Location = new System.Drawing.Point(171, 112);
            this.textBoxWS.Name = "textBoxWS";
            this.textBoxWS.Size = new System.Drawing.Size(171, 21);
            this.textBoxWS.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "수위조절센서 상태 : ";
            // 
            // buttonOn
            // 
            this.buttonOn.Enabled = false;
            this.buttonOn.Location = new System.Drawing.Point(6, 237);
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.Size = new System.Drawing.Size(336, 40);
            this.buttonOn.TabIndex = 8;
            this.buttonOn.Text = "작동 시작";
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Click += new System.EventHandler(this.buttonOn_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Location = new System.Drawing.Point(6, 191);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(336, 40);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "온도 설정 적용";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(6, 329);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(336, 40);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "종료";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "서버 주소 : ";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(98, 20);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(244, 21);
            this.textBoxIP.TabIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(10, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(159, 34);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 88);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "서버 설정";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOff);
            this.groupBox2.Controls.Add(this.textBoxWS);
            this.groupBox2.Controls.Add(this.textBoxTS);
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonOn);
            this.groupBox2.Controls.Add(this.buttonApply);
            this.groupBox2.Controls.Add(this.textBoxGT);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxST);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 381);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "욕조 상태";
            // 
            // buttonOff
            // 
            this.buttonOff.Enabled = false;
            this.buttonOff.Location = new System.Drawing.Point(6, 283);
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.Size = new System.Drawing.Size(336, 40);
            this.buttonOff.TabIndex = 11;
            this.buttonOff.Text = "작동 정지";
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Click += new System.EventHandler(this.buttonOff_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstRxdData);
            this.groupBox3.Location = new System.Drawing.Point(12, 499);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 148);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // lstRxdData
            // 
            this.lstRxdData.FormattingEnabled = true;
            this.lstRxdData.ItemHeight = 12;
            this.lstRxdData.Location = new System.Drawing.Point(6, 18);
            this.lstRxdData.Name = "lstRxdData";
            this.lstRxdData.Size = new System.Drawing.Size(336, 124);
            this.lstRxdData.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(183, 48);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(159, 34);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "연결 해제";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // SmartBathControlUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 657);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmartBathControlUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartBath";
            this.Load += new System.EventHandler(this.SmartBathControlUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTS;
        private System.Windows.Forms.TextBox textBoxWS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOn;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOff;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstRxdData;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

