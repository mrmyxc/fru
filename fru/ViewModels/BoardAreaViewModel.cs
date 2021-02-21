using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using fru.Helpers;
using fru.Models;
using ReactiveUI;

namespace fru.ViewModels
{
    public class BoardAreaViewModel : ViewModelBase
    {
        public BoardArea BoardArea { get; }

        private DateTime _manuTime;

        public BoardAreaViewModel(BoardArea boardArea)
        {
            BoardArea = boardArea;

            this.WhenAnyValue(vm => vm.PartNumberLength,
                              vm => vm.SerialNumberLength,
                              vm => vm.ProductNameLength,
                              vm => vm.ManuNameLength,
                              vm => vm.FruFileIDLength)
                .Subscribe(x => 
                {
                    int length = (x.Item1 + x.Item2 + x.Item3 + x.Item4 + x.Item5 + 5 + 6 + 1);
                    BoardArea.padding = (8 - (length % 8));
                    Length = length + BoardArea.padding; // add padding to length
                });

            this.WhenAnyValue(vm => vm.ManufacturerDateTime).Subscribe(mdt =>
            {
                ManufacturerTime = (int) (mdt.ToUniversalTime() - Hel.timeStartOffset).TotalMinutes;
            });

            this.WhenAnyValue(vm => vm.ManuName, vm => vm.ManuNameType).Subscribe(name =>
            {
                ManuNameLength = ManuName.Length;
            });

            this.WhenAnyValue(vm => vm.ProductName, vm => vm.ProductNameType).Subscribe(name =>
            {
                ProductNameLength = ProductName.Length;
            });

            this.WhenAnyValue(vm => vm.PartNumber, vm => vm.PartNumberType).Subscribe(name =>
            {
                PartNumberLength = PartNumber.Length;
            });

            this.WhenAnyValue(vm => vm.SerialNumber, vm => vm.SerialNumberType).Subscribe(name =>
            {
                SerialNumberLength = SerialNumber.Length;
            });

            this.WhenAnyValue(vm => vm.FruFileID, vm => vm.FruFileIDType).Subscribe(name =>
            {
                FruFileIDLength = FruFileID.Length;
            });

            var ob1 = this.WhenAnyValue(vm => vm.PartNumber,
                              vm => vm.SerialNumber,
                              vm => vm.ProductName,
                              vm => vm.ManuName,
                              vm => vm.FruFileID);


            var ob2 = this.WhenAnyValue(vm => vm.ManufacturerTime,
                              vm => vm.ManuNameType,
                              vm => vm.SerialNumberType,
                              vm => vm.ProductNameType,
                              vm => vm.FruFileIDType,
                              vm => vm.PartNumberType);

            ob1.CombineLatest(ob2).Subscribe( _ => 
            {
                var b = BoardArea.GetBoardAreaBytes();
                Checksum = b.Last();
                Bytes = BitConverter.ToString(b.ToArray());
            });

            GenerateBytes = ReactiveCommand.Create(BoardArea.GetBoardAreaBytes, Observable.Return(true));
            GenerateBytes.Subscribe(result => 
            {
                Debug.WriteLine(result);
                Bytes = "0x" + BitConverter.ToString(result.ToArray()).Replace("-", " 0x");
            });

            Bytes = "hello";
        }

        public ReactiveCommand<Unit, List<byte>> GenerateBytes { get; }

        public string _bytes;

        private string Bytes
        {
            get { return _bytes; }
            set { this.RaiseAndSetIfChanged(ref _bytes, value); }
        }

        public byte FormatVersion
        {
            get { return BoardArea.formatVersion; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.formatVersion, value); }
        }

        public int Length
        {
            get { return BoardArea.actualLength; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.actualLength, value); }
        }

        public LanguageCode LanguageCode
        {
            get { return BoardArea.languageCode; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.languageCode, value); }
        }
        
        public DateTime ManufacturerDateTime
        {
            get { return _manuTime; }
            set { this.RaiseAndSetIfChanged(ref _manuTime, value); }
        }

        private int ManufacturerTime
        {
            get { return BoardArea.mfgminutes; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.mfgminutes, value); }
        }

        public Helpers.TypeCode ManuNameType
        {
            get { return BoardArea.manufacuturer.typeLength.type; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.manufacuturer.typeLength.type, value); }
        }

        public int ManuNameLength
        {
            get { return BoardArea.manufacuturer.typeLength.length; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.manufacuturer.typeLength.length, value); }
        }

        public string ManuName
        {
            get { return BoardArea.manufacuturer.value; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.manufacuturer.value, value); }
        }

        public Helpers.TypeCode SerialNumberType
        {
            get { return BoardArea.serialNumber.typeLength.type; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.serialNumber.typeLength.type, value); }
        }

        public int SerialNumberLength
        {
            get { return BoardArea.serialNumber.typeLength.length; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.serialNumber.typeLength.length, value); }
        }

        public string SerialNumber
        {
            get { return BoardArea.serialNumber.value; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.serialNumber.value, value); }
        }

        public Helpers.TypeCode ProductNameType
        {
            get { return BoardArea.productName.typeLength.type; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.partNumber.typeLength.type, value); }
        }

        public int ProductNameLength
        {
            get { return BoardArea.productName.typeLength.length; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.productName.typeLength.length, value); }
        }

        public string ProductName
        {
            get { return BoardArea.productName.value; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.productName.value, value); }
        }

        public Helpers.TypeCode PartNumberType
        {
            get { return BoardArea.partNumber.typeLength.type; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.partNumber.typeLength.type, value); }
        }

        public int PartNumberLength
        {
            get { return BoardArea.partNumber.typeLength.length; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.partNumber.typeLength.length, value); }
        }

        public string PartNumber
        {
            get { return BoardArea.partNumber.value; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.partNumber.value, value); }
        }

        public Helpers.TypeCode FruFileIDType
        {
            get { return BoardArea.fileID.typeLength.type; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.fileID.typeLength.type, value); }
        }

        public int FruFileIDLength
        {
            get { return BoardArea.fileID.typeLength.length; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.fileID.typeLength.length, value); }
        }

        public string FruFileID
        {
            get { return BoardArea.fileID.value; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.fileID.value, value); }
        }

        public byte Checksum
        {
            get { return BoardArea.checksum; }
            set { this.RaiseAndSetIfChanged(ref BoardArea.checksum, value); }
        }

        public IEnumerable<LanguageCode> LanguageCodeList
        {
            get
            {
                return Enum.GetValues(typeof(LanguageCode))
                    .Cast<LanguageCode>();
            }
        }

        public IEnumerable<Helpers.TypeCode> TypeCodeList
        {
            get
            {
                return Enum.GetValues(typeof(Helpers.TypeCode))
                    .Cast<Helpers.TypeCode>();
            }
        }
    }
}
