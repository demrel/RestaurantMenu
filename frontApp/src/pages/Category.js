import {
    Text,
    Flex,
    Button,
    Input,
    Box
} from '@chakra-ui/react'


import { useState, useEffect } from 'react'
import axios from 'axios'
import { CategoryItem } from '../components'
import { toBase64 } from '../Helper'

const baseData = [
    {
        name: 'Isti Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',
    },
    {
        name: 'Soyuq Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',
    }
];


export default function Category() {
    const [allData, setAllData] = useState(null)
    const [postValue, setPostValue] = useState(null)


    const SetInputPosValue = (e) => {
        setPostValue(
            {
                ...postValue,
                [e?.target.name]: e?.target?.value
            }
        )
    }

      const  setInputfilterImageData =async (e) => {
          const base64Image=await toBase64(e?.target?.files[0]);
            setPostValue(
                {
                    ...postValue,
                    [e?.target.name]: base64Image
                }
            )
        }


    useEffect(() => {
        console.log('FilterValuyular', postValue)
    }, [postValue])


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
            filtervalue: postValue
        })
            .then(function (response) {
                console.log(response);
                // setAllData(response)
            })
            .catch(function (error) {
                console.log(error);
            });

        console.log('Duyme isledi', postValue)
    }

    return (
        <>
            <Flex justify={'center'} width='100%' marginTop={"40px"}>
                <Flex flexDirection={'row'} height='100px' width='50%' align={'center'} justifyContent='space-around' >
                    <Input name='name' size='lg' marginLeft={'10px'} placeholder='Name' onChange={(e) => SetInputPosValue(e)} />
                    <Input name='price' size='lg' marginLeft={'10px'} placeholder='Description' onChange={(e) => SetInputPosValue(e)} />
                     <Input type="file" name='base64Image' size='lg' marginLeft={'10px'} placeholder='Basic usage' aria-hidden="true" accept="image/*" onChange={(e) => setInputfilterImageData(e)} /> 
                    <Button colorScheme='teal' size='lg' marginLeft={'10px'} onClick={getFilterData} >Add</Button>
                </Flex>
            </Flex>
            <Flex height='100vh' width='100vw' justifyContent={'center'} backgroundColor='#CCCCCC'>
                <Flex width={'1000px'} alignItems='center' flexDirection={'column'}>
                    <Text fontSize={'40px'}>Categories</Text>
                    <Box  width={'100%'} margin="40px">
                        {allData?.map((item, index) => {
                            return (<CategoryItem item={item} key={index}/>)
                        })}
                    </Box>
                </Flex>
            </Flex>
        </>
    );
}