import {
    Text,
    Flex,
    Button,
    Input,
    Box,
    Select
} from '@chakra-ui/react'


import { useState, useEffect } from 'react'
import axios from 'axios'
import { MenuItem } from '../components'
import { toBase64 } from '../Helper'


const baseData =
{
    categoryList: [
        {
            id:1,
            name:"isti",
        },
        {
            id:2,
            name:"isti2",
        },
        {
            id:3,
            name:"isti3",
        }
    ],
    products: [
        {
            name: 'Et',
            description: 'Test et desc',
            ingridients: ['et', 'yag', 'sarimsaq'],
            price: 10.20,
            imageUrl: 'https://picsum.photos/200',
        },
        {
            name: 'Et2',
            description: 'Test et desc2',
            ingridients: ['et', 'yag', 'sarimsaq'],
            price: 10.220,
            imageUrl: 'https://picsum.photos/200',
        },
        {
            name: 'Et3',
            description: 'Test et desc3',
            ingridients: ['et', 'yag', 'sarimsaq'],
            price: 10.30,
            imageUrl: 'https://picsum.photos/200',
        }
    ]
}


export default function Product() {
    const [allData, setAllData] = useState(null)
    const [filtervalue, setFilterValue] = useState(null)

    const setInputfilterData = (e) => {
        setFilterValue(
            {
                ...filtervalue,
                [e?.target.name]: e?.target?.value
            }
        )
    }

    const setInputfilterImageData = async (e) => {
        const base64Image = await toBase64(e?.target?.files[0]);
        setFilterValue(
            {
                ...filtervalue,
                [e?.target.name]: base64Image
            }
        )
    }



    useEffect(() => {
        console.log('FilterValuyular', filtervalue)
    }, [filtervalue])


    useEffect(() => {
        setAllData(baseData)
        getApidata()
    }, [])

    const getApidata = async () => {
        const response = await axios.get('https://jsonplaceholder.typicode.com/users');
        // setAllData(response)
    }

    const getFilterData = async () => {
        const getData = await axios.post('https://jsonplaceholder.typicode.com/users', {
            filtervalue
        })
            .then(function (response) {
                console.log(response);
                // setAllData(response)
            })
            .catch(function (error) {
                console.log(error);
            });

        console.log('Duyme isledi', filtervalue)
    }

    return (
        <>
            <Flex justify={'center'} width='100%' marginTop={"40px"}>
                <Flex flexDirection={'row'} height='100px' width='80%' align={'center'} justifyContent='space-around' >
                    <Input name='name' size='lg' marginLeft={'10px'} placeholder='Name' onChange={(e) => setInputfilterData(e)} />
                    <Input name='description' size='lg' marginLeft={'10px'} placeholder='Description' onChange={(e) => setInputfilterData(e)} />
                    <Input name='price' size='lg' marginLeft={'10px'} placeholder='Price' onChange={(e) => setInputfilterData(e)} />
                    <Select size='lg' marginLeft={'10px'} placeholder='Select option'>
                        {allData?.categoryList?.map(cat => {
                          return(<option value={cat.id}>{cat.name}</option>)
                        })}
                    </Select>

                    <Input name="ingridients" label="Tags" size='lg' marginLeft={'10px'} placeholder="Seperate ignridients with Delimiter" onChange={e => setInputfilterData(e)} />
                    <Input type="file" name='base64Image' size='lg' marginLeft={'10px'} placeholder='Basic usage' aria-hidden="true" accept="image/*" onChange={(e) => setInputfilterImageData(e)} />
                    <Button colorScheme='teal' size='lg' marginLeft={'10px'} onClick={getFilterData} >Add</Button>
                </Flex>
            </Flex>
            <Flex height='100vh' width='100vw' justifyContent={'center'} backgroundColor='#CCCCCC'>
                <Flex width={'1000px'} alignItems='center' flexDirection={'column'}>
                    <Text fontSize={'40px'}>Products</Text>

                    <Box width={'100%'} margin="40px">
                        {allData?.products?.map((product, index) => {
                            return (<MenuItem item={product} />)

                        })}
                    </Box>

                </Flex>
            </Flex>
        </>
    );
}