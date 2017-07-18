/**
 * Created by Thao Nguyen on 07/18/2017.
 */
import React, {Component} from 'react';
import './App.css';


var data = [{name: 'Jhon', age: 28, city: 'HO'}, {name: 'Onhj', age: 82, city: 'HN'}, {
    name: 'Nohj',
    age: 41,
    city: 'IT'
}]


class TableRow extends Component {
    render() {
        /* the ES6 version of const data = this.props.data */
        var obj = this.props.data;
        /*
         use map to perform the same function on
         each element in the obj array
         */
        return (
            <tr>
                <td>{obj.name}</td>
                <td>{obj.age}</td>
                <td>{obj.city}</td>
            </tr>
        );
    }
}

class Table extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        var _data = this.props.data;
        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Company</th>
                            <th>Contact</th>
                            <th>Country</th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        _data.map(function (object, i) {
                            return <tr key={i}>
                                <td>{object.name}</td>
                                <td>{object.age}</td>
                                <td>{object.city}</td>
                            </tr>;
                        })
                    }
                    </tbody>
                </table>
            </div>
        );
    }
}

class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: "Thao",
            value: "123"
        };
    }


    render() {
        return (
            <div>
                <Table data={data}/>
            </div>
        );
    }

}

export default Home;
