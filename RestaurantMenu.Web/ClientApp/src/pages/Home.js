import {
    Text,
    Box,
    Flex,
    Image,
    Button,
    Input,
} from '@chakra-ui/react'


import { useState, useEffect } from 'react';
import axios from 'axios'
import { MenuItemCard } from '../components'


const baseData = [
    {
        name: 'Isti Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',
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


    },
    {
        name: 'Soyuq Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',
        products: [
            {
                name: 'Sezar',
                description: 'Test et desc',
                ingridients: ['et', 'yag', 'sarimsaq'],
                price: 10.20,
                imageUrl: 'https://picsum.photos/200',
            },
            {
                name: 'Sezar2',
                description: 'Test et desc2',
                ingridients: ['et', 'yag', 'sarimsaq'],
                price: 10.220,
                imageUrl: 'https://picsum.photos/200',
            },
            {
                name: 'Sezar3',
                description: 'Test et desc3',
                ingridients: ['et', 'yag', 'sarimsaq'],
                price: 10.30,
                imageUrl: 'https://picsum.photos/200',
            }
        ]


    }
];


export default function Home() {
    const [allData, setAllData] = useState(null)
    const [filtervalue, setFilterValue] = useState(null)


    const setInputfilterData = (e) => {
        setFilterValue(
            {
                ...filtervalue,
                [e.target.name]: e.target.value
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
                <Flex flexDirection={'row'} height='100px' width='50%' align={'center'} justifyContent='space-around' >
                    <Input name='name' size='md' marginLeft={'10px'} placeholder='Basic usage' onChange={(e) => setInputfilterData(e)} />
                    <Input name='price' size='md' marginLeft={'10px'} placeholder='Basic usage' onChange={(e) => setInputfilterData(e)} />
                    <Input name='tag' size='md' marginLeft={'10px'} placeholder='Basic usage' onChange={(e) => setInputfilterData(e)} />
                    <Button colorScheme='teal' size='lg' marginLeft={'10px'} onClick={getFilterData} >Filter</Button>
                </Flex>
            </Flex>
            <Flex height='100vh' width='100vw' justifyContent={'center'} backgroundColor='#CCCCCC'>
                <Flex width={'1000px'} alignItems='center' flexDirection={'column'}>
                    <Text fontSize={'40px'}>MENU</Text>
                    {allData?.map((item, index) => {
                        return (

                            <Box key={index} width={'100%'} margin="40px">
                                <Box width={'100%'} border={'1px solid white'}  >
                                    <Flex flexDirection={'row'} height='100px' width='100%' align={'center'} justifyContent='space-around' >
                                        <Text fontSize={'30px'}>{item?.name}</Text>
                                        <Image height={'80px'} width='80px' src={item?.imageUrl} alt='Dan Abramov' />
                                    </Flex>
                                    <Text align={"center"}>{item?.description}</Text>
                                </Box>
                                {item.products.map( (product)=>{
                                    return(<MenuItemCard item={product} />)
                                })}
                             
                            </Box>
                        )
                    })}
                </Flex>
            </Flex>
        </>
    );
}