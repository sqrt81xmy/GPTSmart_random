﻿/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using BenchmarkDotNet.Attributes;
using Nethermind.Core.Extensions;
using Nethermind.Evm;

namespace Nethermind.Benchmarks.Evm
{
    [MemoryDiagnoser]
    [CoreJob(baseline: true)]
    public class JumpDestinationsBenchmark
    {
        private byte[][] _scenarios = new[]
        {
            Bytes.FromHexString("60606040525b600080fd00a165627a7a7230582012c9bd00152fa1c480f6827f81515bb19c3e63bf7ed9ffbb5fda0265983ac7980029"),
            Bytes.FromHexString("0x608060405234801561001057600080fd5b506040516040806119738339810180604052604081101561003057600080fd5b50805160209091015160008054600160a060020a0319163317808255604051600160a060020a039190911691907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0908290a3600160a060020a03821615156100f957604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152601e60248201527f43616e6e6f742073657420666565206163636f756e7420746f203078302e0000604482015290519081900360640190fd5b606460ff82161115610156576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260218152602001806119526021913960400191505060405180910390fd5b6002805460ff909216740100000000000000000000000000000000000000000260a060020a60ff0219600160a060020a03909416600160a060020a031990931692909217929092161790556117a2806101b06000396000f3fe6080604052600436106100fa576000357c0100000000000000000000000000000000000000000000000000000000900480638f32d59b1161009c578063d0386d9711610076578063d0386d971461035e578063f2fde38b14610433578063fc17e94014610473578063fffc780114610527576100fa565b80638f32d59b1461027b578063a001ecdd146102a4578063c48f28ed146102cf576100fa565b806365e17c9d116100d857806365e17c9d146101e25780636e9fb85114610220578063715018a6146102515780638da5cb5b14610266576100fa565b80633d4dff7b146100ff5780634b023cf81461015d5780634cc537cd1461019f575b600080fd5b34801561010b57600080fd5b506101296004803603602081101561012257600080fd5b5035610572565b604080516bffffffffffffffffffffffff909416845263ffffffff9283166020850152911682820152519081900360600190f35b34801561016957600080fd5b5061019d6004803603602081101561018057600080fd5b503573ffffffffffffffffffffffffffffffffffffffff166105c1565b005b3480156101ab57600080fd5b506101c9600480360360208110156101c257600080fd5b50356106bc565b6040805163ffffffff9092168252519081900360200190f35b3480156101ee57600080fd5b506101f76106e4565b6040805173ffffffffffffffffffffffffffffffffffffffff9092168252519081900360200190f35b61019d6004803603606081101561023657600080fd5b5080359063ffffffff60208201358116916040013516610700565b34801561025d57600080fd5b5061019d61093e565b34801561027257600080fd5b506101f76109ef565b34801561028757600080fd5b50610290610a0b565b604080519115158252519081900360200190f35b3480156102b057600080fd5b506102b9610a29565b6040805160ff9092168252519081900360200190f35b3480156102db57600080fd5b5061019d600480360360e08110156102f257600080fd5b5080359063ffffffff60208201358116916bffffffffffffffffffffffff60408201351691606082013516906fffffffffffffffffffffffffffffffff196080820135169073ffffffffffffffffffffffffffffffffffffffff60a082013581169160c0013516610a4a565b34801561036a57600080fd5b5061019d600480360361018081101561038257600080fd5b60408051808201825283359363ffffffff60208201358116946bffffffffffffffffffffffff8584013516946060840135909216936fffffffffffffffffffffffffffffffff196080850135169373ffffffffffffffffffffffffffffffffffffffff60a082013581169460c08301359091169382019261012083019160e084019060029083908390808284376000920191909152509194505060ff82351692505060208101359060400135610ca2565b34801561043f57600080fd5b5061019d6004803603602081101561045657600080fd5b503573ffffffffffffffffffffffffffffffffffffffff166111b0565b34801561047f57600080fd5b5061019d600480360361016081101561049757600080fd5b5080359063ffffffff60208201358116916bffffffffffffffffffffffff6040820135169160608201358116916fffffffffffffffffffffffffffffffff196080820135169173ffffffffffffffffffffffffffffffffffffffff60a083013581169260c08101359092169160ff60e0820135169161010082013591610120810135916101409091013516611209565b34801561053357600080fd5b506105516004803603602081101561054a57600080fd5b5035611556565b604080516bffffffffffffffffffffffff9092168252519081900360200190f35b6001602052600090815260409020546bffffffffffffffffffffffff81169063ffffffff6c01000000000000000000000000820481169170010000000000000000000000000000000090041683565b6105c9610a0b565b151561060e576040516000805160206116de83398151915281526004018080602001828103825260268152602001806116886026913960400191505060405180910390fd5b73ffffffffffffffffffffffffffffffffffffffff8116151561068057604080516000805160206116de833981519152815260206004820152601e60248201527f43616e6e6f742073657420666565206163636f756e7420746f203078302e0000604482015290519081900360640190fd5b6002805473ffffffffffffffffffffffffffffffffffffffff191673ffffffffffffffffffffffffffffffffffffffff92909216919091179055565b6000908152600160205260409020546c01000000000000000000000000900463ffffffff1690565b60025473ffffffffffffffffffffffffffffffffffffffff1681565b8215801590610714575063ffffffff821615155b801561072f57508163ffffffff163481151561072c57fe5b06155b80156107485750346bffffffffffffffffffffffff1634145b15156107a357604080516000805160206116de833981519152815260206004820152601a60248201527f496e76616c696420696e70757420746f2066756e6374696f6e2e000000000000604482015290519081900360640190fd5b4263ffffffff8216116107ef576040516000805160206116de833981519152815260040180806020018281038252602a81526020018061174d602a913960400191505060405180910390fd5b6000838152600160205260409020546c01000000000000000000000000900463ffffffff161561086e57604080516000805160206116de833981519152815260206004820152601960248201527f6465706f736974494420616c7265616479206578697374732e00000000000000604482015290519081900360640190fd5b5050604080516060810182526bffffffffffffffffffffffff348116825263ffffffff42811660208085019182526000858701818152978152600190915294909420925183549451955182167001000000000000000000000000000000000273ffffffff0000000000000000000000000000000019969092166c01000000000000000000000000027fffffffffffffffffffffffffffffffff00000000ffffffffffffffffffffffff919093166bffffffffffffffffffffffff1990951694909417939093161792909216179055565b610946610a0b565b151561098b576040516000805160206116de83398151915281526004018080602001828103825260268152602001806116886026913960400191505060405180910390fd5b6000805460405173ffffffffffffffffffffffffffffffffffffffff909116907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0908390a36000805473ffffffffffffffffffffffffffffffffffffffff19169055565b60005473ffffffffffffffffffffffffffffffffffffffff1690565b60005473ffffffffffffffffffffffffffffffffffffffff16331490565b60025474010000000000000000000000000000000000000000900460ff1681565b6040805160208082018a90527c010000000000000000000000000000000000000000000000000000000063ffffffff808b16820284860152740100000000000000000000000000000000000000006bffffffffffffffffffffffff8b1602604485015288160260508301526fffffffffffffffffffffffffffffffff19861660548301526c0100000000000000000000000073ffffffffffffffffffffffffffffffffffffffff80871682026064850152339190910260788401528351606c818503018152608c9093018452825192820192909220600081815260019092529290209083161515610b8a57604080516000805160206116de833981519152815260206004820152601d60248201527f526566756e64546f20616464726573732063616e6e6f7420626520302e000000604482015290519081900360640190fd5b805460006bffffffffffffffffffffffff909116118015610bd85750428663ffffffff16111580610bd85750805463ffffffff89811670010000000000000000000000000000000090920416145b1515610c1d576040516000805160206116de833981519152815260040180806020018281038252602a8152602001806116fe602a913960400191505060405180910390fd5b805460405173ffffffffffffffffffffffffffffffffffffffff8516916bffffffffffffffffffffffff1680156108fc02916000818181858888f19350505050158015610c6e573d6000803e3d6000fd5b50506000908152600160205260409020805473ffffffffffffffffffffffffffffffffffffffff1916905550505050505050565b6040805160208082018e90527c010000000000000000000000000000000000000000000000000000000063ffffffff8e8116820284860152740100000000000000000000000000000000000000006bffffffffffffffffffffffff8f160260448501528c8116820260508501526fffffffffffffffffffffffffffffffff198c1660548501526c0100000000000000000000000073ffffffffffffffffffffffffffffffffffffffff8c8116820260648701528b1690810260788601528551606c818703018152608c86018752805190850120600081815260018087528882208d518e89015160ac8b01869052908716880260cc8b015290951690950260d0880152875180880360b401815260d48801808a5281519188019190912091905260f487018089525260ff8a1661011487015261013486018990526101548601889052955191949093610174808301939192601f198301929081900390910190855afa158015610e14573d6000803e3d6000fd5b5050506020604051035173ffffffffffffffffffffffffffffffffffffffff16141515610e7a576040516000805160206116de83398151915281526004018080602001828103825260258152602001806117286025913960400191505060405180910390fd5b4263ffffffff8b1611610ec6576040516000805160206116de833981519152815260040180806020018281038252602a81526020018061174d602a913960400191505060405180910390fd5b8551815463ffffffff91821670010000000000000000000000000000000090910490911611801590610f0757506020860151865163ffffffff918216911611155b8015610f1f5750602086015163ffffffff8d81169116105b1515610f7a57604080516000805160206116de833981519152815260206004820152601260248201527f496e76616c696420756e69742072616e67650000000000000000000000000000604482015290519081900360640190fd5b6000610fc1610fb56bffffffffffffffffffffffff8e168984602002015163ffffffff168a6001602002015163ffffffff1603600101611576565b8e63ffffffff166115aa565b90506000610feb610fe483600260149054906101000a900460ff1660ff16611576565b60646115aa565b90506000610ff983836115ce565b9050826bffffffffffffffffffffffff16831480156110255750806bffffffffffffffffffffffff1681145b151561108057604080516000805160206116de833981519152815260206004820152601c60248201527f43617374696e6720636175736564206c6f7373206f6620646174612e00000000604482015290519081900360640190fd5b801561119e5760405173ffffffffffffffffffffffffffffffffffffffff8c169082156108fc029083906000818181858888f193505050501580156110c9573d6000803e3d6000fd5b5081156111195760025460405173ffffffffffffffffffffffffffffffffffffffff9091169083156108fc029084906000818181858888f19350505050158015611117573d6000803e3d6000fd5b505b8354611133906bffffffffffffffffffffffff16846115ce565b84546bffffffffffffffffffffffff19166bffffffffffffffffffffffff919091161784558860016020020151845473ffffffff000000000000000000000000000000001916700100000000000000000000000000000000600190920163ffffffff16919091021784555b50505050505050505050505050505050565b6111b8610a0b565b15156111fd576040516000805160206116de83398151915281526004018080602001828103825260268152602001806116886026913960400191505060405180910390fd5b611206816115e3565b50565b6040805160208082018e90527c010000000000000000000000000000000000000000000000000000000063ffffffff808f16820284860152740100000000000000000000000000000000000000006bffffffffffffffffffffffff8f160260448501528c160260508301526fffffffffffffffffffffffffffffffff198a1660548301526c0100000000000000000000000073ffffffffffffffffffffffffffffffffffffffff808b1682026064850152339190910260788401528351606c818503018152608c909301845282519282019290922060008181526001909252929020908316151561134957604080516000805160206116de833981519152815260206004820152601d60248201527f526566756e64546f20616464726573732063616e6e6f7420626520302e000000604482015290519081900360640190fd5b805460006bffffffffffffffffffffffff90911611801561136f5750428763ffffffff16105b801561138057508963ffffffff1642105b15156113c5576040516000805160206116de83398151915281526004018080602001828103825260308152602001806116ae6030913960400191505060405180910390fd5b6040805160208082018590527c010000000000000000000000000000000000000000000000000000000063ffffffff8b16028284015282516024818403018152604483018085528151918301919091206000909152606483018085525260ff8916608483015260a4820188905260c48201879052915173ffffffffffffffffffffffffffffffffffffffff8b169260019260e480820193601f1981019281900390910190855afa15801561147d573d6000803e3d6000fd5b5050506020604051035173ffffffffffffffffffffffffffffffffffffffff161415156114e3576040516000805160206116de83398151915281526004018080602001828103825260258152602001806117286025913960400191505060405180910390fd5b805460405173ffffffffffffffffffffffffffffffffffffffff8516916bffffffffffffffffffffffff1680156108fc02916000818181858888f19350505050158015611534573d6000803e3d6000fd5b5080546bffffffffffffffffffffffff19169055505050505050505050505050565b6000908152600160205260409020546bffffffffffffffffffffffff1690565b6000821515611587575060006115a4565b82820282848281151561159657fe5b04146115a157600080fd5b90505b92915050565b60008082116115b857600080fd5b600082848115156115c557fe5b04949350505050565b6000828211156115dd57600080fd5b50900390565b73ffffffffffffffffffffffffffffffffffffffff8116151561160557600080fd5b6000805460405173ffffffffffffffffffffffffffffffffffffffff808516939216917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e091a36000805473ffffffffffffffffffffffffffffffffffffffff191673ffffffffffffffffffffffffffffffffffffffff9290921691909117905556fe4f6e6c7920746865206f776e65722063616e2063616c6c20746869732066756e6374696f6e2e496e73756666696369656e7420726571756972656d656e747320746f20636c61696d206561726c7920726566756e642e08c379a000000000000000000000000000000000000000000000000000000000496e73756666696369656e7420726571756972656d656e747320746f20636c61696d20726566756e642e5369676e617475726520696e636f727265637420666f7220676976656e2076616c7565732e65787069727954696d657374616d70206d757374206265203e20626c6f636b2e74696d657374616d702ea165627a7a723058203285db6b1a0de8377c6b1a934a045aecb19a4d34b010b227c67b1fa3b12a9d8e002943616e6e6f742068617665206665652070657263656e74616765203e203130302e0000000000000000000000002b5ad5c4795c026514f8317c7a215e218dccd6cf0000000000000000000000000000000000000000000000000000000000000014"),
        };

        private CodeInfo _codeInfo;

        [Params(0, 1)]
        public int ScenarioIndex { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _codeInfo = new CodeInfo(_scenarios[ScenarioIndex]);
        }

        [Benchmark]
        public bool Improved()
        {
            return _codeInfo.ValidateJump(0);
        }

        [Benchmark]
        public bool Current()
        {
            return _codeInfo.ValidateJump(0);
        }
    }
}