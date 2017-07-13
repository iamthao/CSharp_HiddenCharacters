import React from 'react';
import './IncreamentNumber.css';/**
 * Created by Thao Nguyen on 07/13/2017.
 */


//-------- IncreamentNumber ----
class Tang extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            number: 0
        }
    };

    render() {
        //console.log(this)
        var {number} = this.state;

        return (
            <div className="div-center padding-top-10">
                <p>{number}</p>
                <p>
                    <button onClick={this.tangLen.bind(this)}> +</button>
                    <button onClick={this.giamXuong.bind(this)}> -</button>
                </p>
            </div>
        );
    }

    tangLen() {
        this.setState({number: this.state.number + 1});
    };

    giamXuong() {
        this.setState({number: this.state.number - 1});
    }

}

export default Tang;